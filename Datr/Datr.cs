using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            if (minValue == null && range == Range.GreaterThan)
            {
                throw new ArgumentException("SetIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue == null && range == Range.LessThan)
            {
                throw new ArgumentException("SetIntRange: minValue must not be null when using the GreaterThan range");
            }

            if (maxValue != null && maxValue <= minValue)
            {
                throw new ArgumentException("SetIntRange: maxValue cannot be less than or equal to minValue");
            }

            if (minValue == int.MaxValue)
            {
                throw new ArgumentException("SetIntRange: minValue cannot be equal to int.MaxValue");
            }

            if (!HasProperty<T>(propertyName))
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
            if (property.PropertyType.IsPrimitive)
            {
                var propertyInstance = Activator.CreateInstance(property.PropertyType);
                switch(propertyInstance)
                {
                    case bool t:
                        property.SetValue(instance, _randomizer.Bool());
                        break;

                    case sbyte t:
                        property.SetValue(instance, _randomizer.SByte());
                        break;

                    case byte t:
                        property.SetValue(instance, _randomizer.Byte());
                        break;

                    case short t:
                        property.SetValue(instance, _randomizer.Short());
                        break;

                    case ushort t:
                        property.SetValue(instance, _randomizer.UShort());
                        break;

                    case char t:
                        property.SetValue(instance, _randomizer.Char());
                        break;

                    case double t:
                        property.SetValue(instance, _randomizer.Double());
                        break;

                    case float t:
                        property.SetValue(instance, _randomizer.Float());
                        break;

                    case uint t:
                        property.SetValue(instance, _randomizer.UInt());
                        break;

                    case long t:
                        property.SetValue(instance, _randomizer.Long());
                        break;

                    case ulong t:
                        property.SetValue(instance, _randomizer.ULong());
                        break;

                    case int t:
                        var method = this.GetType().GetMethod("GetFixedRange");
                        var genericMethod = method.MakeGenericMethod(instance.GetType());
                        var range = (FixedRange)genericMethod.Invoke(this, new[] { property });
                        var value = range == null ? _randomizer.Int() : _randomizer.FixedRangeInt(range);
                        property.SetValue(instance, value);
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
                    property.SetValue(instance, _randomizer.String());
                }
                else
                {
                    var method = this.GetType().GetMethod("Create");
                    var genericMethod = method.MakeGenericMethod(property.PropertyType);
                    var populatedClass = genericMethod.Invoke(this, null);
                    property.SetValue(instance, populatedClass);
                }
            }
        }

        public FixedRange GetFixedRange<T>(PropertyInfo property) => 
            FixedRanges.FirstOrDefault(r => (Type)r.ClassType == typeof(T) && r.PropertyName.ToLower() == property.Name.ToLower());

        private bool HasProperty<T>(string propertyName)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.ToLower() == propertyName.ToLower())
                    return true;
            }

            return false;
        }
    }
}
