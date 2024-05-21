
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class UOMForGetList
    {
        public int ID { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Package { get; set; }
        public string Details { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public UOMForGetList(int id,double quantity,string unit,string pack,string detail)
        {
            this.ID = id;
            this.Quantity = quantity;
            this.Unit = unit;
            this.Package = pack;
            this.Details = detail;
        }

        public static List<UOMForGetList> GetUOMList()
        {
            MySqlConnection conn = null;
            List<UOMForGetList> uomlist = new List<UOMForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM uom";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            double quantity = Convert.ToDouble(reader["Quantity"]);
                            string unit = reader["UnitOfUOMName"].ToString();
                            string pack = reader["PackageName"].ToString();
                            string des = reader["Name"].ToString();

                            uomlist.Add(new UOMForGetList(id, quantity, unit, pack, des));
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
            return uomlist;
        }
    }
}
