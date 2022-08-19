using System;

namespace Mizza.DataModels.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreProperty : Attribute
    {
        public IgnoreProperty(bool value = true)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}