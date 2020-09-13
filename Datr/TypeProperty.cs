using System;

namespace Datr
{
    public class TypeProperty
    {
        public Type Type { get; private set; }
        public string PropertyName { get; private set; }

        /// <summary>
        /// A class used for referring to a specific property of a given type
        /// </summary>
        /// <param name="type">The type to which the property belongs</param>
        /// <param name="propertyName">The name of the property being referenced</param>
        public TypeProperty(Type type, string propertyName)
        {
            Type = type;
            PropertyName = propertyName;
        }
    }
}
