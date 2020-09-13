using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Datr
{
    public class Datr
    {
        public List<string> ExcludedPropertyNames { get; set; }
        public List<TypeProperty> ExcludedTypeProperties { get; set; }
        public List<FixedValue> FixedValues { get; set; }
        private Randomizer _randomizer { get; set; }

        public Datr()
        {
            ExcludedPropertyNames = new List<string>();
            ExcludedTypeProperties = new List<TypeProperty>();
            FixedValues = new List<FixedValue>();

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
                        property.SetValue(instance, _randomizer.Int());
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
    }
}
