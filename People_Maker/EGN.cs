using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_Maker
{
    public static class EGN
    {
        //Клас за генериране на случайно ЕГН
        public static string EGNMaker(char gender)
        {
            var egn = new StringBuilder();
            //Първи 6 цифри: година, месец, ден
            DateTime birth = new DateTime(1970, 1, 1);
            Random rnd = new Random();
            birth = birth.AddDays(rnd.Next(10000));
            egn.Append(birth.Year.ToString().Substring(2, 2));
            if (birth.Month < 10) { egn.Append(0); egn.Append(birth.Month.ToString()); }
            else egn.Append(birth.Month.ToString());
            if (birth.Day < 10) { egn.Append(0); egn.Append(birth.Day.ToString()); }
            else egn.Append(birth.Day.ToString());
            //3-цифрено число за област и четност/нечетност за пол
            int r = 0;
            if (gender == 'm')
                while (r % 2 != 1)
                    r = rnd.Next(1000);
            else
            {
                r = 1;
                while (r % 2 == 1)
                    r = rnd.Next(1000);
            }
            if (r < 10) egn.Append("00");
            else if (r < 100) egn.Append("0");
            egn.Append(r);
            //контролна цифра образуваща се по долуизползваната формула
            int contr = 0;
            contr = egn[0] * 2 + egn[1] * 4 + egn[2] * 8 + egn[3] * 5 + egn[4] * 10 + egn[5] * 9 + egn[6] * 7 + egn[7] * 3 + egn[8] * 6;
            if (contr % 11 == 10) egn.Append(0);
            else egn.Append(contr % 11);
            return egn.ToString();
        }
    }
}
