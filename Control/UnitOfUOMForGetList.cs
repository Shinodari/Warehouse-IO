
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class UnitOfUOMForGetList
    {
        public string Name { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public  UnitOfUOMForGetList(string name)
        {
            this.Name = name;
        }

        public static List<UnitOfUOMForGetList> GetUnitOfUOM()
        {
            List<UnitOfUOMForGetList> unitofuomlist = new List<UnitOfUOMForGetList>();
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM unitofuom";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            unitofuomlist.Add(new UnitOfUOMForGetList(name));
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
            return unitofuomlist;
        }
    }
}
