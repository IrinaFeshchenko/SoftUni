namespace SimpleMvcFramework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribure
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "GET";
        }
    }
}
