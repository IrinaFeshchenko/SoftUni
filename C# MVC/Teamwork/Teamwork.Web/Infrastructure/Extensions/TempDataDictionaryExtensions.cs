using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Teamwork.Web.Infrastructure.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataErrorMessageKey] = message;
        }

        public static string SuccessMessage(this ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey(WebConstants.TempDataSuccessMessageKey))
            {
                return tempData[WebConstants.TempDataSuccessMessageKey].ToString();
            }
            else
            {
                return null;
            }
        }

        public static string ErrorMessage(this ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey(WebConstants.TempDataErrorMessageKey))
            {
                return tempData[WebConstants.TempDataErrorMessageKey].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
