using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect2SQL3
{
    public class getList
    {
        public static string[] getHero(){

            List<string> list = new List<string>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "andysandboxdbsrv.database.windows.net";
                builder.UserID = "andyl123";
                builder.Password = "Qwerty00!";
                builder.InitialCatalog = "fightingsqldb";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //Console.WriteLine("\nExtracting data...");
                    //Console.WriteLine("=========================================\n");

                    String sql = "SELECT Person_Name FROM FightingGame.Person WHERE PersonType = 'Hero'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(reader.GetString(0));
                            }
                        }
                    }
                }

                return list.ToArray();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
