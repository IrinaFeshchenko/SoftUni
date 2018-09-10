using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Chat.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataErrorMessageKey] = message;
        }

        public static string SuccessMessage(this ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey(TempDataSuccessMessageKey))
            {
                return tempData[TempDataSuccessMessageKey].ToString();
            }
            else
            {
                return null;
            }
        }

        public static string ErrorMessage(this ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey(TempDataErrorMessageKey))
            {
                return tempData[TempDataErrorMessageKey].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
