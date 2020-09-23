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
        public List<FixedRange> FixedRanges { get; set; }
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

        public void SetIntRange<T>(string propertyName, Range range, int? minValue = null, int? maxValue = null)
        {
            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetIntRange: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetIntRange: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException("SetIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException("SetIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (minValue == int.MaxValue)
            {
                throw new ArgumentException("SetIntRange: minValue cannot be equal to int.MaxValue");
            }

            if (maxValue == int.MinValue)
            {
                throw new ArgumentException("SetIntRange: maxValue cannot be equal to int.MinValue");
            }

            if (!HasProperty<T, int>(propertyName))
            {
                throw new ArgumentException($"SetIntRange: The type {typeof(T).Name} does not contain the property {propertyName}");
            }

            var intRange = new FixedRange
            {
                DataType = typeof(int),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(intRange);
        }

        public void SetUIntRange<T>(string propertyName, Range range, uint? minValue = null, uint? maxValue = null)
        {
            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetUIntRange: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException("SetUIntRange: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException("SetUIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException("SetUIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (minValue == uint.MaxValue)
            {
                throw new ArgumentException("SetUIntRange: minValue cannot be equal to uint.MaxValue");
            }

            if (maxValue == uint.MinValue)
            {
                throw new ArgumentException("SetUIntRange: maxValue cannot be equal to uint.MinValue");
            }

            if (!HasProperty<T, uint>(propertyName))
            {
                throw new ArgumentException($"SetUIntRange: The type {typeof(T).Name} does not contain the property {propertyName}");
            }

            var uintRange = new FixedRange
            {
                DataType = typeof(uint),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(uintRange);
        }

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

            if (minValue == uint.MaxValue)
            {
                throw new ArgumentException("SetStringRange: minValue cannot be equal to uint.MaxValue");
            }

            if (minValue <= 0 || maxValue <= 0)
            {
                throw new ArgumentException("SetStringRange: minValue and maxValue cannot less than or equal to zero");
            }

            if (!HasProperty<T, uint>(propertyName))
            {
                throw new ArgumentException($"SetUIntRange: The type {typeof(T).Name} does not contain the property {propertyName}");
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
            var method = this.GetType().GetMethod("GetFixedRange");
            var genericMethod = method.MakeGenericMethod(instance.GetType());
            var range = (FixedRange)genericMethod.Invoke(this, new[] { property });

            if (property.PropertyType.IsPrimitive)
            {
                var propertyInstance = Activator.CreateInstance(property.PropertyType);
                switch (propertyInstance)
                {
                    case bool t:
                        property.SetValue(instance, _randomizer.Bool());
                        break;

                    case char t:
                        property.SetValue(instance, _randomizer.Char());
                        break;

                    case sbyte t:
                        var sbyteValue = range == null ? _randomizer.SByte() : _randomizer.FixedRangeSByte(range);
                        property.SetValue(instance, sbyteValue);
                        break;

                    case byte t:
                        var byteValue = range == null ? _randomizer.Byte() : _randomizer.FixedRangeByte(range);
                        property.SetValue(instance, byteValue);
                        break;

                    case short t:
                        var shortValue = range == null ? _randomizer.Short() : _randomizer.FixedRangeShort(range);
                        property.SetValue(instance, shortValue);
                        break;

                    case ushort t:
                        var ushortValue = range == null ? _randomizer.UShort() : _randomizer.FixedRangeUShort(range);
                        property.SetValue(instance, ushortValue);
                        break;

                    case double t:
                        var doubleValue = range == null ? _randomizer.Double() : _randomizer.FixedRangeDouble(range);
                        property.SetValue(instance, doubleValue);
                        break;

                    case float t:
                        var floatValue = range == null ? _randomizer.Float() : _randomizer.FixedRangeFloat(range);
                        property.SetValue(instance, floatValue);
                        break;

                    case int t:
                        var intValue = range == null ? _randomizer.Int() : _randomizer.FixedRangeInt(range);
                        property.SetValue(instance, intValue);
                        break;

                    case uint t:
                        var uintValue = range == null ? _randomizer.UInt() : _randomizer.FixedRangeUInt(range);
                        property.SetValue(instance, uintValue);
                        break;

                    case long t:
                        var longValue = range == null ? _randomizer.Long() : _randomizer.FixedRangeLong(range);
                        property.SetValue(instance, longValue);
                        break;

                    case ulong t:
                        var ulongValue = range == null ? _randomizer.ULong() : _randomizer.FixedRangeULong(range);
                        property.SetValue(instance, ulongValue);
                        break;
                }
            }
            else
            {
                if (property.PropertyType == typeof(decimal))
                        property.SetValue(instance, _randomizer.Decimal());
            }

            if (property.PropertyType.IsClass)
            {
                if (property.PropertyType == typeof(string))
                {
                    var stringValue = range == null ? _randomizer.String() : _randomizer.FixedRangeString(range);
                    property.SetValue(instance, stringValue);
                }
                else
                {
                    var createMethod = this.GetType().GetMethod("Create");
                    var genericCreateMethod = createMethod.MakeGenericMethod(property.PropertyType);
                    var populatedClass = genericCreateMethod.Invoke(this, null);
                    property.SetValue(instance, populatedClass);
                }
            }
        }

        public FixedRange GetFixedRange<T>(PropertyInfo property) => 
            FixedRanges.FirstOrDefault(r => (Type)r.ClassType == typeof(T) && r.PropertyName.ToLower() == property.Name.ToLower());

        private bool HasProperty<T, U>(string propertyName) =>
            typeof(T).GetProperties().Any(p => p.Name.ToLower() == propertyName.ToLower() && p.PropertyType == typeof(U));
    }
}
