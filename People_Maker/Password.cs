using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_Maker
{
    public static class Password
    {
        public static string GeneratePassword()
        {
            char[] symbols = new char[]
            {
                'z', 'x', 'c', 'v', 'b', 'n', 'm', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
                'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'Z', 'X', 'C', 'V', 'B', 'N', 'M',
                'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I',
                'O', 'P', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
            };
            var pass = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
                pass.Append(symbols[rnd.Next(symbols.Length)]);
            return pass.ToString();
        }
    }
}
