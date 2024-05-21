
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class PackageForGetList
    {
        public string Name { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public  PackageForGetList(string name)
        {
            this.Name = name;
        }

        public static List<PackageForGetList> GetPackageList()
        {
            List<PackageForGetList> packagelist = new List<PackageForGetList>();
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
                            packagelist.Add(new PackageForGetList(name));
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
