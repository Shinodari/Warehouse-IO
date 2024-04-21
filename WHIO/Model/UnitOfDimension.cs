using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class UnitOfDimension : Unit
    {
        static string connstr = Settings.Default.CONNECTION_STRING;
        public UnitOfDimension(string name) : base(name) { }

        public static List<UnitOfDimension> GetUnitOfDimension()
        {
            List<UnitOfDimension> unitofdimensionlist = new List<UnitOfDimension>();
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = "SELECT * FROM unitofdimension";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                UnitOfDimension item = new UnitOfDimension(name);
                                unitofdimensionlist.Add(item);
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
            return unitofdimensionlist;
        }
    }
}
