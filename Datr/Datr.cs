﻿using System;
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
            ValidateRange<int, T>(propertyName, range, minValue, maxValue);

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
            ValidateRange<uint, T>(propertyName, range, minValue, maxValue);

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

        public void SetDecimalRange<T>(string propertyName, Range range, decimal? minValue = null, decimal? maxValue = null)
        {
            ValidateRange<decimal, T>(propertyName, range, minValue, maxValue);

            var decimalRange = new FixedRange
            {
                DataType = typeof(decimal),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(decimalRange);
        }

        public void SetSByteRange<T>(string propertyName, Range range, sbyte? minValue = null, sbyte? maxValue = null)
        {
            ValidateRange<sbyte, T>(propertyName, range, minValue, maxValue);

            var decimalRange = new FixedRange
            {
                DataType = typeof(sbyte),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(decimalRange);
        }

        public void SetByteRange<T>(string propertyName, Range range, byte? minValue = null, byte? maxValue = null)
        {
            ValidateRange<byte, T>(propertyName, range, minValue, maxValue);

            var decimalRange = new FixedRange
            {
                DataType = typeof(byte),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(decimalRange);
        }

        public void SetShortRange<T>(string propertyName, Range range, short? minValue = null, short? maxValue = null)
        {
            ValidateRange<short, T>(propertyName, range, minValue, maxValue);

            var shortRange = new FixedRange
            {
                DataType = typeof(short),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(shortRange);
        }

        public void SetUShortRange<T>(string propertyName, Range range, ushort? minValue = null, ushort? maxValue = null)
        {
            ValidateRange<ushort, T>(propertyName, range, minValue, maxValue);

            var ushortRange = new FixedRange
            {
                DataType = typeof(ushort),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(ushortRange);
        }

        public void SetFloatRange<T>(string propertyName, Range range, float? minValue = null, float? maxValue = null)
        {
            ValidateRange<float, T>(propertyName, range, minValue, maxValue);

            var floatRange = new FixedRange
            {
                DataType = typeof(float),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(floatRange);
        }

        public void SetDoubleRange<T>(string propertyName, Range range, double? minValue = null, double? maxValue = null)
        {
            ValidateRange<double, T>(propertyName, range, minValue, maxValue);

            var doubleRange = new FixedRange
            {
                DataType = typeof(double),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(doubleRange);
        }

        public void SetLongRange<T>(string propertyName, Range range, long? minValue = null, long? maxValue = null)
        {
            ValidateRange<long, T>(propertyName, range, minValue, maxValue);

            var longRange = new FixedRange
            {
                DataType = typeof(long),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(longRange);
        }

        public void SetULongRange<T>(string propertyName, Range range, ulong? minValue = null, ulong? maxValue = null)
        {
            ValidateRange<ulong, T>(propertyName, range, minValue, maxValue);

            var ulongRange = new FixedRange
            {
                DataType = typeof(ulong),
                ClassType = typeof(T),
                PropertyName = propertyName,
                Range = range,
                MinValue = minValue,
                MaxValue = maxValue
            };

            FixedRanges.Add(ulongRange);
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

            if (minValue == int.MaxValue)
            {
                throw new ArgumentException("SetStringRange: minValue cannot be equal to uint.MaxValue");
            }

            if (minValue <= 0 || maxValue <= 0)
            {
                throw new ArgumentException("SetStringRange: minValue and maxValue cannot less than or equal to zero");
            }

            if (!HasProperty<T, string>(propertyName))
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

            var underlyingNullableType = Nullable.GetUnderlyingType(property.PropertyType);

            if (property.PropertyType.IsPrimitive || underlyingNullableType?.IsPrimitive == true)
            {
                var propertyInstance = 
                    underlyingNullableType == null ? Activator.CreateInstance(property.PropertyType) : Activator.CreateInstance(underlyingNullableType);

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
                if (property.PropertyType == typeof(decimal) || underlyingNullableType == typeof(decimal))
                {
                    var decimalValue = range == null ? _randomizer.Decimal() : _randomizer.FixedRangeDecimal(range);
                    property.SetValue(instance, decimalValue);
                }

                if (property.PropertyType == typeof(DateTime))
                {
                    var dateTimeValue = _randomizer.DateTime();
                    property.SetValue(instance, dateTimeValue);
                }
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

        private void ValidateRange<PropertyType, ContainingClass>(string propertyName, Range range, dynamic minValue, dynamic maxValue)
        {
            if ((minValue == null || maxValue == null) && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: minValue and maxValue parameters must be set when using a range of Between or Outside.");
            }

            if (maxValue <= minValue && (range == Range.Between || range == Range.Outside))
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: maxValue cannot be less than or equal to minValue when using a range of Between or Outside");
            }

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: minValue must not be null when using the GreaterThan range");
            }

            var min = (PropertyType)typeof(PropertyType).GetField("MinValue").GetValue(null);
            var max = (PropertyType)typeof(PropertyType).GetField("MaxValue").GetValue(null);

            if (minValue == max)
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: minValue cannot be equal to {typeof(PropertyType).Name}.MaxValue");
            }

            if (maxValue == min)
            {
                throw new ArgumentException($"Set{typeof(PropertyType).Name}Range: maxValue cannot be equal to {typeof(PropertyType).Name}.MinValue");
            }

            if (!HasProperty<ContainingClass, PropertyType>(propertyName))
            {
                throw new ArgumentException($"Set{typeof(ContainingClass).Name}Range: The type {typeof(ContainingClass).Name} does not contain the property {propertyName}");
            }
        }
    }
}
