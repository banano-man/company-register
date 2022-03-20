using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People_Maker
{
    class WorkPlace
    {
        public string toDataBase = "";
        //В зависимост от предварително зададени параметри се генгерира работното място на човек X във фирма Y
        public WorkPlace(int person_Id, int firm_Id, int role_Id)
        {
            string conString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = Firm_Register; Integrated Security=True";
            SqlConnection Con = new SqlConnection(@conString);
            SqlCommand Cmd = new SqlCommand("INSERT INTO WorkPlaces" +
            "(Person_Id, Firm_Id, Role_Id) " +
                    "VALUES(@Person_Id, @Firm_Id, @Role_Id)", Con);
            Cmd.Parameters.Add("@Person_Id", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Firm_Id", System.Data.SqlDbType.Int);
            Cmd.Parameters.Add("@Role_Id", System.Data.SqlDbType.Int);

            try
            {
                Cmd.Parameters["@Person_Id"].Value = person_Id;
                Cmd.Parameters["@Firm_Id"].Value = firm_Id;
                Cmd.Parameters["@Role_Id"].Value = role_Id;

                Con.Open();
                Cmd.ExecuteNonQuery();
                toDataBase = $"('{person_Id}', '{firm_Id}', '{role_Id}'),";
                Con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
        }
    }
}
