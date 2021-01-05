using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Datr
{
    public class Datr
    {
        public List<string> ExcludedPropertyNames { get; set; }
        public List<TypeProperty> ExcludedTypeProperties { get; set; }
        public List<FixedValue> FixedValues { get; set; }
        public List<FixedRange> FixedRanges { get; private set; }
        private Randomizer _randomizer { get; set; }

        public Datr()
        {
            ExcludedPropertyNames = new List<string>();
            ExcludedTypeProperties = new List<TypeProperty>();
            FixedValues = new List<FixedValue>();
            FixedRanges = new List<FixedRange>();

            _randomizer = new Randomizer();
        }

        /// <summary>
        /// Create a populated instance of the given type
        /// </summary>
        /// <typeparam name="T">The type to be created</typeparam>
        /// <returns>Populated instance of the given type</returns>
        public T Create<T>()
        {
            var instance = Activator.CreateInstance(typeof(T));
            var properties = instance.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (!IgnoreProperty<T>(property))
                {
                    if (FixedValues.Any(f => f.Type == typeof(T) && f.PropertyName.ToLower() == property.Name.ToLower()))
                    {
                        try
                        {
                            var fixedValue = FixedValues.Single(f => f.Type == typeof(T) && f.PropertyName.ToLower() == property.Name.ToLower());
                            property.SetValue(instance, fixedValue.Value);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        SetRandomPropertyValue(property, instance);
                    }
                }
            }

            return (T)instance;
        }

        /// <summary>
        /// Sets a fixed range of values for the given class and int property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetIntRange<T>(string propertyName, Range range, int? minValue = null, int? maxValue = null) => SetRange<int, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and uint property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetUIntRange<T>(string propertyName, Range range, uint? minValue = null, uint? maxValue = null) => SetRange<uint, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and decimal property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetDecimalRange<T>(string propertyName, Range range, decimal? minValue = null, decimal? maxValue = null) => SetRange<decimal, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and sbyte property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetSByteRange<T>(string propertyName, Range range, sbyte? minValue = null, sbyte? maxValue = null) => SetRange<sbyte, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and byte property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetByteRange<T>(string propertyName, Range range, byte? minValue = null, byte? maxValue = null) => SetRange<byte, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and short property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetShortRange<T>(string propertyName, Range range, short? minValue = null, short? maxValue = null) => SetRange<short, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and ushort property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetUShortRange<T>(string propertyName, Range range, ushort? minValue = null, ushort? maxValue = null) => SetRange<ushort, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and float property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetFloatRange<T>(string propertyName, Range range, float? minValue = null, float? maxValue = null) => SetRange<float, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and double property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetDoubleRange<T>(string propertyName, Range range, double? minValue = null, double? maxValue = null) => SetRange<double, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and long property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetLongRange<T>(string propertyName, Range range, long? minValue = null, long? maxValue = null) => SetRange<long, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of values for the given class and ulong property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetULongRange<T>(string propertyName, Range range, ulong? minValue = null, ulong? maxValue = null) => SetRange<ulong, T>(propertyName, range, minValue, maxValue);

        /// <summary>
        /// Sets a fixed range of lengths for the given class and string property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum length of the string</param>
        /// <param name="maxValue">The maximum length of the string</param>
        public void SetStringRange<T>(string propertyName, Range range, int? minValue = null, int? maxValue = null)
        {
            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetStringRange: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetStringRange: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException("SetStringRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException("SetStringRange: minValue must not be null when using the GreaterThan range");
            }

            if (minValue == int.MaxValue)
            {
                throw new ArgumentException("SetStringRange: minValue cannot be equal to uint.MaxValue");
            }

            if (minValue <= 0 || maxValue <= 0)
            {
                throw new ArgumentException("SetStringRange: minValue and maxValue cannot less than or equal to zero");
            }

            if (!HasProperty<T>(propertyName))
            {
                throw new ArgumentException($"SetStringRange: The type {typeof(T).Name} does not contain the property {propertyName}");
            }

            var stringRange = new FixedRange
            {
                DataType = typeof(string),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(stringRange);
        }

        /// <summary>
        /// Sets a fixed range of values for the given class and DateTime property
        /// </summary>
        /// <typeparam name="T">The class containing the property</typeparam>
        /// <param name="propertyName">The name of the property (case insensitive)</param>
        /// <param name="range">The range for the property to be generated in. Greater than, Less Than, Between or Outside</param>
        /// <param name="minValue">The minimum value of the property</param>
        /// <param name="maxValue">The maximum value of the property</param>
        public void SetDateTimeRange<T>(string propertyName, Range range, DateTime? minValue = null, DateTime? maxValue = null)
        {
            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetDateTimeRange: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetDateTimeRange: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException("SetDateTimeRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException("SetDateTimeRange: minValue must not be null when using the GreaterThan range");
            }

            if (minValue == DateTime.MaxValue)
            {
                throw new ArgumentException("SetDateTimeRange: minValue cannot be equal to DateTime.MaxValue");
            }

            if (maxValue == DateTime.MinValue)
            {
                throw new ArgumentException("SetDateTimeRange: maxValue cannot be equal to DateTime.MinValue");
            }

            if (!HasProperty<T>(propertyName))
            {
                throw new ArgumentException($"SetDateTimeRange: The type {typeof(T).Name} does not contain the property {propertyName}");
            }

            var stringRange = new FixedRange
            {
                DataType = typeof(DateTime),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(stringRange);
        }

        private bool IgnoreProperty<T>(PropertyInfo property)
        {
            if (ExcludedPropertyNames.Any(p => p.ToLower() == property.Name.ToLower()))
            {
                return true;
            }

            if (ExcludedTypeProperties.Any(t => t.Type == typeof(T) && t.PropertyName.ToLower() == property.Name.ToLower()))
            {
                return true;
            }

            return false;
        }

        private void SetRandomPropertyValue<T>(PropertyInfo property, T instance)
        {
            var method = this.GetType().GetMethod("GetFixedRange", BindingFlags.NonPublic | BindingFlags.Instance);
            var genericMethod = method.MakeGenericMethod(instance.GetType());
            var range = (FixedRange)genericMethod.Invoke(this, new[] { property });

            dynamic value;

            if (property.PropertyType.IsArray)
            {
                var arrayElements = _randomizer.Byte();
                var elementType = property.PropertyType.GetElementType();

                value = Array.CreateInstance(elementType, arrayElements);
                
                for (var i = 0; i < arrayElements; i++)
                {
                    var val = GetRandomPropertyValue(property, range);
                    value[i] = val;
                }
            }
            else if (property.PropertyType.IsEnum)
            {
                var enumVals = Enum.GetValues(property.PropertyType);

                var fixedRange = new FixedRange
                {
                    Range = Range.Between,
                    MinValue = 0,
                    MaxValue = enumVals.Length
                };

                var randomValueIndex = _randomizer.FixedRangeInt(fixedRange);

                value = Enum.Parse(property.PropertyType, enumVals.GetValue(randomValueIndex).ToString());
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var listElements = _randomizer.Byte();

                value = Activator.CreateInstance(property.PropertyType);
                for (var i = 0; i < listElements; i++)
                {
                    var listValue = GetRandomPropertyValue(property, range);
                    value.Add(listValue);
                }
            }
            else
            {
                value = GetRandomPropertyValue(property, range);
            }

            property.SetValue(instance, value);
        }

        private dynamic GetRandomPropertyValue(PropertyInfo property, FixedRange range)
        {
            Type propertyType;
            if (property.PropertyType.IsArray)
            {
                propertyType = property.PropertyType.GetElementType();
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                propertyType = property.PropertyType.GetGenericArguments()[0];
            }
            else
            {
                propertyType = property.PropertyType;
            }

            var underlyingNullableType = Nullable.GetUnderlyingType(propertyType);
            
            if (propertyType.IsPrimitive || underlyingNullableType?.IsPrimitive == true)
            {
                var propertyInstance =
                    underlyingNullableType == null ? Activator.CreateInstance(propertyType) : Activator.CreateInstance(underlyingNullableType);

                switch (propertyInstance)
                {
                    case bool t:
                        return _randomizer.Bool();

                    case char t:
                        return _randomizer.Char();

                    case sbyte t:
                        return range == null ? _randomizer.SByte() : _randomizer.FixedRangeSByte(range);

                    case byte t:
                        return range == null ? _randomizer.Byte() : _randomizer.FixedRangeByte(range);

                    case short t:
                        return range == null ? _randomizer.Short() : _randomizer.FixedRangeShort(range);

                    case ushort t:
                        return range == null ? _randomizer.UShort() : _randomizer.FixedRangeUShort(range);

                    case double t:
                        return range == null ? _randomizer.Double() : _randomizer.FixedRangeDouble(range);

                    case float t:
                        return range == null ? _randomizer.Float() : _randomizer.FixedRangeFloat(range);

                    case int t:
                        return range == null ? _randomizer.Int() : _randomizer.FixedRangeInt(range);

                    case uint t:
                        return range == null ? _randomizer.UInt() : _randomizer.FixedRangeUInt(range);

                    case long t:
                        return range == null ? _randomizer.Long() : _randomizer.FixedRangeLong(range);

                    case ulong t:
                        return range == null ? _randomizer.ULong() : _randomizer.FixedRangeULong(range);
                }
            }
            else
            {
                if (propertyType == typeof(decimal) || underlyingNullableType == typeof(decimal))
                {
                    return range == null ? _randomizer.Decimal() : _randomizer.FixedRangeDecimal(range);
                }

                if (propertyType == typeof(DateTime))
                {
                    return range == null ? _randomizer.DateTime() : _randomizer.FixedRangeDateTime(range);
                }
            }

            if (propertyType.IsClass)
            {
                if (propertyType == typeof(string))
                {
                    return range == null ? _randomizer.String() : _randomizer.FixedRangeString(range);
                }
                else
                {
                    var createMethod = this.GetType().GetMethod("Create");
                    var genericCreateMethod = createMethod.MakeGenericMethod(propertyType);
                    var populatedClass = genericCreateMethod.Invoke(this, null);
                    return populatedClass;
                }
            }

            return null;
        }

        private bool HasProperty<T>(string propertyName) =>
            typeof(T).GetProperties().Any(p => p.Name.ToLower() == propertyName.ToLower());

        private FixedRange GetFixedRange<T>(PropertyInfo property) =>
            FixedRanges.FirstOrDefault(r => (Type)r.ClassType == typeof(T) && r.PropertyName.ToLower() == property.Name.ToLower());

        private void SetRange<PropertyType, ContainingClass>(string propertyName, Range range, dynamic minValue, dynamic maxValue)
        {
            ValidateRange<PropertyType, ContainingClass>(propertyName, range, minValue, maxValue);

            var fixedRange = new FixedRange
            {
                DataType = typeof(PropertyType),
                ClassType = typeof(ContainingClass),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(fixedRange);
        }

        private void ValidateRange<PropertyType, ContainingClass>(string propertyName, Range range, dynamic minValue, dynamic maxValue)
        {
            var propertyTypeName = typeof(PropertyType).Name;

            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: minValue must not be null when using the GreaterThan range");
            }

            var min = (PropertyType)typeof(PropertyType).GetField("MinValue").GetValue(null);
            var max = (PropertyType)typeof(PropertyType).GetField("MaxValue").GetValue(null);

            if (minValue == max)
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: minValue cannot be equal to {propertyTypeName}.MaxValue");
            }

            if (maxValue == min)
            {
                throw new ArgumentException($"Set{propertyTypeName}Range: maxValue cannot be equal to {propertyTypeName}.MinValue");
            }

            if (!HasProperty<ContainingClass>(propertyName))
            {
                throw new ArgumentException($"Set{typeof(ContainingClass).Name}Range: The type {typeof(ContainingClass).Name} does not contain the property {propertyName}");
            }
        }
    }
}
