using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Package : Unit
    {
        static string connstr = Settings.Default.CONNECTION_STRING;
        public Package(string name) : base(name) { }

        public static List<Package> GetPackageList()
        {
            List<Package> packagelist = new List<Package>();
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = "SELECT * FROM package";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                Package item = new Package(name);
                                packagelist.Add(item);
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
            return packagelist;
        }
    }
}
