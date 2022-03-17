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
            Dictionary<string, List<string>> females = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> femalesCopy = new Dictionary<string, List<string>>();
            Console.WriteLine("Въведи брой записи: ");
            int n = int.Parse(Console.ReadLine());
            int maleCount = n / 2, femaleCount = n - maleCount;
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT Male_Name FROM dbo.Males;",
                  connection);
                connection.Open();
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
            Random rnd = new Random();
            for(int i = 1; i <= maleCount; i++)
            {
                int rndFirstName = rnd.Next(males.Count);
                string FirstName = males.ElementAt(rndFirstName).Key;
                int rndLastName = rnd.Next(males[FirstName].Count);
                Person person = new Person(FirstName, males[FirstName][rndLastName], 'm');
                //Console.WriteLine(FirstName + " " + males[FirstName][rndLastName] + " " + 'm');
                if (malesCopy.ContainsKey(FirstName)) malesCopy[FirstName].Add(males[FirstName][rndLastName]);
                else
                {
                    malesCopy.Add(FirstName, new List<string>());
                    malesCopy[FirstName].Add(males[FirstName][rndLastName]);
                }
                males[FirstName].Remove(males[FirstName][rndLastName]);
                if (males[FirstName].Count == 0) males.Remove(FirstName);
                if (males.Count == 0) { males = malesCopy; malesCopy.Clear(); }
                
            }
            for(int i = 1; i <= femaleCount; i++)
            {
                int rndFirstName = rnd.Next(females.Count);
                string FirstName = females.ElementAt(rndFirstName).Key;
                int rndLastName = rnd.Next(females[FirstName].Count);
                Person person = new Person(FirstName, females[FirstName][rndLastName], 'f');
                //Console.WriteLine(FirstName + " " + females[FirstName][rndLastName] + " " + 'f');
                if (femalesCopy.ContainsKey(FirstName)) femalesCopy[FirstName].Add(females[FirstName][rndLastName]);
                else
                {
                    femalesCopy.Add(FirstName, new List<string>());
                    femalesCopy[FirstName].Add(females[FirstName][rndLastName]);
                }
                females[FirstName].Remove(females[FirstName][rndLastName]);
                if (females[FirstName].Count == 0) females.Remove(FirstName);
                if (females.Count == 0) { females = femalesCopy; femalesCopy.Clear(); }
            }
            Console.ReadKey(true);
        }
    }
}
