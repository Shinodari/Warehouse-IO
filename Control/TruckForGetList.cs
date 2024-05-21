using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class TruckForGetList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public TruckForGetList(int id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }

        public static List<TruckForGetList> GetTruckList()
        {
            MySqlConnection conn = null;
            List<TruckForGetList> truckList = new List<TruckForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM truck";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = reader["Name"].ToString();
                            string des = reader["Description"].ToString();
                            truckList.Add(new TruckForGetList(id, name, des));
                        }
                    }
                }
            }
            catch (MySqlException e) { }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return truckList;
        }
    }
}