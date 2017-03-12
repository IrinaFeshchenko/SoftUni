namespace _5.Photographers.Attributes
{
    using System.ComponentModel.DataAnnotations;

    class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object tag)
        {
            string tagValue = (string)tag;

            if (!tagValue.StartsWith("#"))
            {
                return false;
            }

            if (tagValue.Contains(" ") || tagValue.Contains("\t"))
            {
                return false;
            }

            if (tagValue.Length > 20)
            {
                return false;
            }

            return true;
        }
    }
}
