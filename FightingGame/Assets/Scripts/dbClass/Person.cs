using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect2SQL3
{
    internal class Person
    {
        public String Name { get; set; }
        public Double HP { get; set; }
        public Double Damage { get; set; }
        public Double MovementSpeed { get; set; }
        public Double Cooldown { get; set; }
        public String Type { get; set; }

        public Person(string _name)
        {
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

                    String sql = "SELECT * FROM FightingGame.Person WHERE Person_Name = '" + _name + "'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Name = reader.GetString(0);
                                HP = reader.GetDouble(1);
                                Damage = reader.GetDouble(2);
                                MovementSpeed = reader.GetDouble(5);
                                Cooldown = reader.GetDouble(3);
                                Type = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

           
        }

        public void ShowState()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("HP: " + HP);
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("Movement Speed: " + MovementSpeed);
            Console.WriteLine("Cooldown: " + Cooldown);
            Console.WriteLine("Type: " + Type);
        }


    }
}
