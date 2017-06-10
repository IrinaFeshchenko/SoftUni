namespace _03.Parse_Tags
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            var inputText = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            int tagStartIndex=-1, tagEndIndex=-1;

            while ((tagStartIndex = inputText.IndexOf(openTag)) !=-1 )
            {
                if ((tagEndIndex = inputText.IndexOf(closeTag)) == -1)
                {
                    break;
                }

                string toBeReplaced = inputText.Substring(tagStartIndex,tagEndIndex+closeTag.Length-tagStartIndex);

                int textStartIndex = tagStartIndex + openTag.Length;
                int textLenth = tagEndIndex - textStartIndex;
                string replaceWith = inputText.Substring(textStartIndex,textLenth).ToUpper();

                inputText = inputText.Replace(toBeReplaced, replaceWith);
            }

            Console.WriteLine(inputText);
        }
    }
}
