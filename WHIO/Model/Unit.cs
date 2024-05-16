using MySql.Data.MySqlClient;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    public abstract class Unit
    {
        string name;
        public string Name { get { return name; }set { name = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        string GetTableNameFromClassName()
        {
            string className = GetType().Name;
            string tableName = className.ToLower();
            return tableName;
        }

        public Unit(string name)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                    string tableName = GetTableNameFromClassName();
                    string check = $"SELECT * FROM {tableName} WHERE Name = @name";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@name", name);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                this.name = reader["Name"].ToString();
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
        }

        public abstract bool Create();
        public abstract bool Change();
        public abstract bool Remove();
    }
}