using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace People_Maker
{
    public class Person
    {
        private int index = 0;
        public Person(string First_Name, string Last_Name, char gender)
        {
            //Заявка към базата данни
            string conString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Firm_Register; Integrated Security=True";
            SqlConnection Con = new SqlConnection(@conString);
            SqlCommand CmdId = new SqlCommand("SELECT MAX(Person_Id) FROM People", Con);
             SqlCommand Cmd = new SqlCommand("INSERT INTO People " +
             "(Person_Email, Person_Password, Person_First_Name, Person_Last_Name, Person_EGN) " +
                     "VALUES(@Person_Email, @Person_Password, @Person_First_Name, @Person_Last_Name, @Person_EGN)", Con);
             Cmd.Parameters.Add("@Person_Email", System.Data.SqlDbType.NVarChar);
                 Cmd.Parameters.Add("@Person_Password", System.Data.SqlDbType.NVarChar);
                 Cmd.Parameters.Add("@Person_First_Name", System.Data.SqlDbType.NVarChar);
                 Cmd.Parameters.Add("@Person_Last_Name", System.Data.SqlDbType.NVarChar);
             Cmd.Parameters.Add("@Person_EGN", System.Data.SqlDbType.NVarChar);
             
            try
            {
                //Създаване на елементите и записването им
                string newPassword = Password.GeneratePassword();
                string newEGN = EGN.EGNMaker(gender);
                string newEmail = Email.EmailMaker(First_Name, Last_Name, newEGN);
                Cmd.Parameters["@Person_Password"].Value = newPassword;
                 Cmd.Parameters["@Person_First_Name"].Value = First_Name;
                 Cmd.Parameters["@Person_Last_Name"].Value = Last_Name;
                 Cmd.Parameters["@Person_EGN"].Value = newEGN;
                 Cmd.Parameters["@Person_Email"].Value = newEmail;

                 Con.Open();
                 Cmd.ExecuteNonQuery();
                 index = (int)CmdId.ExecuteScalar();
                Console.WriteLine($"('{newEmail}', '{newPassword}', N'{First_Name}', N'{Last_Name}', {newEGN}),");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
        }
        public int Index { get { return index; } }
    }
}
