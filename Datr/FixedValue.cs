using System;

namespace Datr
{
    public class FixedValue
    {
        public Type Type { get; private set; }
        public string PropertyName { get; private set; }
        public object Value { get; private set; }

        /// <summary>
        /// Set a given property of a type to a specific value
        /// </summary>
        /// <param name="type">The type containing the desired property</param>
        /// <param name="propertyName">The property of the value to fix</param>
        /// <param name="value">The fixed value to be set</param>
        public FixedValue(Type type, string propertyName, object value)
        {
            Type = type;
            PropertyName = propertyName;
            Value = value;
        }
    }
}
