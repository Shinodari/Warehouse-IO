using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class DeliveryplaceForGetList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public DeliveryplaceForGetList(int id,string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public static List<DeliveryplaceForGetList> GetDeliveryplaceList()
        {
            MySqlConnection conn = null;
            List<DeliveryplaceForGetList> deliveryplaceList = new List<DeliveryplaceForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM deliveryplace";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = reader["Name"].ToString();
                            deliveryplaceList.Add(new DeliveryplaceForGetList(id, name));
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
            return deliveryplaceList;
        }
    }
}
