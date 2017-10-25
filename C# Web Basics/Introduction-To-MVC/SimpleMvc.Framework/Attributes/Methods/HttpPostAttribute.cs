namespace SimpleMvc.Framework.Attributes.Methods
{
    public class HttpPostAttribute : HttpMethodAttribure
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "POST";
        }
    }
}
