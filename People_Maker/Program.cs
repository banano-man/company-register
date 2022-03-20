using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace People_Maker
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server = (LocalDb)\\MSSQLLocalDB; database = Firm_Register; Trusted_Connection = True; MultipleActiveResultSets = true");
            Dictionary<string, List<string>> males = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> malesCopy = new Dictionary<string, List<string>>();
            List<string> workPlaces = new List<string>();
            List<int> firms = new List<int>();
            List<int> firmsCopy = new List<int>();
            Dictionary<string, List<string>> females = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> femalesCopy = new Dictionary<string, List<string>>();
            Console.WriteLine("Въведи брой записи: ");
            int n = int.Parse(Console.ReadLine());
            int firms_Number = 0;
            int maleCount = n / 2, femaleCount = n - maleCount;
            //запълване на речниците males и females с имена и фамилии
            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Firms", connection);
                firms_Number = (Int32)cmd.ExecuteScalar();
                SqlCommand command = new SqlCommand(
                   "SELECT Male_Name FROM dbo.Males;",
                   connection);
                SqlDataReader Male_Reader = command.ExecuteReader();
                while (Male_Reader.Read())
                {
                    males.Add(Male_Reader.GetString(0), new List<string>());
                    SqlCommand commandFamily = new SqlCommand("SELECT Family_Name FROM dbo.Family", connection);
                    SqlDataReader Family_Reader = commandFamily.ExecuteReader();
                    while (Family_Reader.Read())
                    {
                        males[Male_Reader.GetString(0)].Add(Family_Reader.GetString(0));
                    }
                }
                command = new SqlCommand(
                  "SELECT Female_Name FROM dbo.Females;",
                  connection);
                SqlDataReader Female_Reader = command.ExecuteReader();
                while (Female_Reader.Read())
                {
                    females.Add(Female_Reader.GetString(0), new List<string>());
                    SqlCommand commandFamily = new SqlCommand("SELECT Family_Name FROM dbo.Family", connection);
                    SqlDataReader Family_Reader = commandFamily.ExecuteReader();
                    while (Family_Reader.Read())
                    {
                        females[Female_Reader.GetString(0)].Add(Family_Reader.GetString(0) + "а");
                    }
                }
                connection.Close();
            }
            //използване на "брой искани записи / 2" случайни мъжки имена и изпълняването на Person за всеки от тях
            Random rnd = new Random();
            for (int i = 1; i <= firms_Number; i++) firms.Add(i);
            int peopleIntoFirm = 0, addOwner = 1;
            int rndFirm = rnd.Next(firms.Count);
            for (int i = 1; i <= maleCount; i++)
            {
                int rndFirstName = rnd.Next(males.Count);
                string FirstName = males.ElementAt(rndFirstName).Key;
                int rndLastName = rnd.Next(males[FirstName].Count);
                Person person = new Person(FirstName, males[FirstName][rndLastName], 'm');
                //След всеки нов запис даденото име се копира от оригиналния речник и се поставя в нов, като оригиналният запис се изтрива
                if (malesCopy.ContainsKey(FirstName)) malesCopy[FirstName].Add(males[FirstName][rndLastName]);
                else
                {
                    malesCopy.Add(FirstName, new List<string>());
                    malesCopy[FirstName].Add(males[FirstName][rndLastName]);
                }
                males[FirstName].Remove(males[FirstName][rndLastName]);
                //Всеки създаден човек бива "нает" в случайна фирма
                if (person.Index <= firms_Number)
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, addOwner, 2);
                    addOwner++;
                    workPlaces.Add(workPlace.toDataBase);

                }
                else if (peopleIntoFirm == 7)
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, firms[rndFirm], 3);
                    workPlaces.Add(workPlace.toDataBase);
                    peopleIntoFirm++;
                }
                else
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, firms[rndFirm], 4);
                    workPlaces.Add(workPlace.toDataBase);
                    peopleIntoFirm++;
                }
                if (peopleIntoFirm == 8)
                {
                    peopleIntoFirm = 0;
                    firmsCopy.Add(firms[rndFirm]);
                    firms.RemoveAt(rndFirm);
                    if (firms.Count == 0) { firms = firmsCopy; firmsCopy.Clear(); }
                    rndFirm = rnd.Next(firms.Count);
                }
                //Ако исканите записи / 2 са повече от броя на имена в оригиналния речник, след изпразването му той се презарежда
                if (males[FirstName].Count == 0) males.Remove(FirstName);
                if (males.Count == 0) { males = malesCopy; malesCopy.Clear(); }


            }
            //аналогично действие на горния цикъл, но се извършва с женски имена
            for (int i = 1; i <= femaleCount; i++)
            {
                int rndFirstName = rnd.Next(females.Count);
                string FirstName = females.ElementAt(rndFirstName).Key;
                int rndLastName = rnd.Next(females[FirstName].Count);
                Person person = new Person(FirstName, females[FirstName][rndLastName], 'f');
                if (femalesCopy.ContainsKey(FirstName)) femalesCopy[FirstName].Add(females[FirstName][rndLastName]);
                else
                {
                    femalesCopy.Add(FirstName, new List<string>());
                    femalesCopy[FirstName].Add(females[FirstName][rndLastName]);
                }
                females[FirstName].Remove(females[FirstName][rndLastName]);
                //Всеки създаден човек бива "нает" в случайна фирма
                if (person.Index <= firms_Number)
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, addOwner, 2);
                    addOwner++;
                    workPlaces.Add(workPlace.toDataBase);

                }
                else if (peopleIntoFirm == 7)
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, firms[rndFirm], 3);
                    workPlaces.Add(workPlace.toDataBase);
                    peopleIntoFirm++;
                }
                else
                {
                    WorkPlace workPlace = new WorkPlace(person.Index, firms[rndFirm], 4);
                    workPlaces.Add(workPlace.toDataBase);
                    peopleIntoFirm++;
                }
                if (peopleIntoFirm == 8)
                {
                    peopleIntoFirm = 0;
                    firmsCopy.Add(firms[rndFirm]);
                    firms.RemoveAt(rndFirm);
                    if (firms.Count == 0) { firms = firmsCopy; firmsCopy.Clear(); }
                    rndFirm = rnd.Next(firms.Count);
                }
                if (females[FirstName].Count == 0) females.Remove(FirstName);
                if (females.Count == 0) { females = femalesCopy; femalesCopy.Clear(); }
            }
            Console.WriteLine();
            foreach (string row in workPlaces) Console.WriteLine(row);
            Console.ReadKey(true);
        }
    }
}

