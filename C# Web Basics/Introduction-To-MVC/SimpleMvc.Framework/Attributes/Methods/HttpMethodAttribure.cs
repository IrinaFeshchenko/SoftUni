namespace SimpleMvcFramework.Attributes.Methods
{
    using System;

    public abstract class HttpMethodAttribure : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
