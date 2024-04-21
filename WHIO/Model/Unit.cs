using MySql.Data.MySqlClient;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Unit
    {
        protected string name;
        public string Name { get { return name; }set { name = value; } }
        string oldname; //for change
        string newname; //for create

        static string connstr = Settings.Default.CONNECTION_STRING;

        protected virtual string TableName { get { return GetType().Name.ToLower(); } }

        public Unit(string name)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM {TableName} WHERE Name = @name";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@name", name);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                this.name = reader["Name"].ToString();
                                oldname = reader["Name"].ToString();
                            }
                            else
                            {
                                newname = name;
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

        public bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string insert = $"INSERT INTO {TableName} (Name) VALUES (@name)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@name", newname);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string update = $"UPDATE {TableName} SET Name = @name WHERE {TableName} . Name = @oldname ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@oldname", oldname);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string delete = $"DELETE FROM {TableName} WHERE Name = @name";
                        cmd.CommandText = delete;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}