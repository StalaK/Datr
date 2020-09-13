using System;

namespace Datr
{
    public class TypeProperty
    {
        public Type Type { get; private set; }
        public string PropertyName { get; private set; }

        public TypeProperty(Type type, string propertyName)
        {
            Type = type;
            PropertyName = propertyName;
        }
    }
}
