using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_Maker
{
    public static class Email
    {
        public static string EmailMaker(string FName, string LName, string EGN)
        {
            FName = FName.ToLower(); LName = LName.ToLower();
            Dictionary<string, string> BgToEng = new Dictionary<string, string>()
            {
                { "а", "a"}, { "б", "b"}, { "в", "v"}, { "г", "g"}, { "д", "d"},
                { "е", "e"}, { "ж", "zh"}, { "з", "z"}, { "и", "i"}, { "й", "y"},
                { "к", "k"}, { "л", "l"}, { "м", "m"}, { "н", "n"}, { "о", "o"},
                { "п", "p"}, { "р", "r"}, { "с", "s"}, { "т", "t"}, { "у", "u"},
                { "ф", "f"}, { "х", "h"}, { "ц", "ts"}, { "ч", "ch"}, { "ш", "sh"},
                { "щ", "sht"}, { "ъ", "a"}, { "ь", "y"}, { "ю", "yu"}, { "я", "ya"}
            };
            var email = new StringBuilder();
            email.Append(BgToEng[FName[0].ToString()]); email.Append('.');
            foreach (char l in LName)
                email.Append(BgToEng[l.ToString()]);
            email.Append(EGN.Substring(0, 6));
            email.Append('@');
            Random rnd = new Random();
            switch (rnd.Next(3))
            {
                case 0: email.Append("gmail.com"); break;
                case 1: email.Append("yahoo.com"); break;
                case 2: email.Append("abv.bg"); break;
            }
            return email.ToString();
        }
    }
}
