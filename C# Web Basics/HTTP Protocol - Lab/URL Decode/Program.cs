using System;
using System.Net;

// input
// http://www.google.bg/search?q=C%23
// https://mysite.com/show?n%40m3= p3%24h0
// http://url-decoder.com/i%23de%25?id=23

namespace URL_Decode
{
    public class Program
    {
        public static void Main()
        {
            string url = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(url);

            Console.WriteLine(decodedUrl);
        }
    }
}
