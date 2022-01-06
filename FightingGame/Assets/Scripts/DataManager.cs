using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Data.SqlClient;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string heroName = "King";
    public string enemyName = "Minion";

    public event EventHandler dataPulled;

    private EntityStat heroStat;
    public EntityStat HeroStat { get { return heroStat; } }
    private EntityStat enemyStat;
    public EntityStat EnemyStat { get { return enemyStat; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("initialising...");
        // Pull data from db
        heroStat = PullData(heroName);
        enemyStat = PullData(enemyName);

        Debug.Log("pulled data. test: herostat: " + heroStat.MovementSpeed);

        StartCoroutine(DelayedEventFiring());
    }

    IEnumerator DelayedEventFiring()
    {
        yield return null;
        dataPulled?.Invoke(this, EventArgs.Empty);
    }

    public EntityStat PullData(string name)
    {
        try
        {
            EntityStat output = new EntityStat();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "andysandboxdbsrv.database.windows.net";
            builder.UserID = "andyl123";
            builder.Password = "Qwerty00!";
            builder.InitialCatalog = "fightingsqldb";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                //Console.WriteLine("\nExtracting data...");
                //Console.WriteLine("=========================================\n");

                string sql = "SELECT * FROM FightingGame.Person WHERE Person_Name = '" + name + "'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.Name = reader.GetString(0);
                            output.HP = (float) reader.GetDouble(1);
                            output.Damage = (float)reader.GetDouble(2);
                            output.MovementSpeed = (float)reader.GetDouble(5);
                            output.Cooldown = (float) reader.GetDouble(3);
                            output.Type = reader.GetString(4);
                        }
                    }
                }
            }

            return output;
        }
        catch (SqlException e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }
}

public class EntityStat
{
    public string Name { get; set; }
    public float HP { get; set; }
    public float Damage { get; set; }
    public float MovementSpeed { get; set; }
    public float Cooldown { get; set; }
    public string Type { get; set; }
}