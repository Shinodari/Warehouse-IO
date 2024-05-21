
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class SupplierForGetList
    {
        public int ID { get; set; }
        public string name { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public SupplierForGetList(int id,string name)
        {
            this.ID = id;
            this.name = name;
        }

        public static List<SupplierForGetList> GetSupplierList()
        {
            MySqlConnection conn = null;
            List<SupplierForGetList> supplierList = new List<SupplierForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM supplier";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = reader["Name"].ToString();
                            supplierList.Add(new SupplierForGetList(id, name));
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
            return supplierList;
        }
    }
}
