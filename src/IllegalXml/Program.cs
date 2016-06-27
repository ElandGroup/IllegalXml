using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IllegalXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1.test visibke illegal character
            string wrongXml = @"<Book>12&</Book>";

            string rightXml = @"<Book>" + ReplaceChar("12&") +"</Book>";

            //2.test invisibke illegal character
            string wrongXmlHide = @"<Book>123</Book>";

            string rightXmlHide = CleanInvalidXmlChars(wrongXmlHide);
        }

        public static string ReplaceChar(string originString)
        {
            if (originString==null)
            {
                return string.Empty;
            }
            else
            {
                return originString.Replace("&", "&amp;")
                    .Replace("<", "&lt;").Replace(">", "&gt;")
                    .Replace("\"", "&quot;").Replace("'", "&apos;");
            }
        }

        public static string CleanInvalidXmlChars(string originString)
        {
            if (originString == null)
            {
                return string.Empty;
            }
            else
            {
                // From xml spec valid chars: 
                // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
                // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
                return Regex.Replace(originString, @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]", "");
            }
        }

    }
}
