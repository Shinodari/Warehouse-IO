using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class UnitOfUOM : Unit
    {
        static string connstr = Settings.Default.CONNECTION_STRING;
        public UnitOfUOM(string name) : base(name) { }

        public static List<UnitOfUOM> GetUnitOfUOM()
        {
            List<UnitOfUOM> unitofuomlist = new List<UnitOfUOM>();
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
                                UnitOfUOM item = new UnitOfUOM(name);
                                unitofuomlist.Add(item);
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
