using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace Warehouse_IO.WHIO.Model
{
    public class Storage
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; } set { name = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void CheckAndUpdateStorage(string columnName,string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM storage WHERE {columnName} = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                name = reader["Name"].ToString();
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
        public Storage(int id)
        {
            CheckAndUpdateStorage("ID",id.ToString());
        }
        public Storage(string name)
        {
            this.name = name;
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
                        string insert = "INSERT INTO storage (ID, Name) VALUES (NULL, @name)";
                        cmd.CommandText = insert;
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
        public bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string update = "UPDATE storage SET Name = @name WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id.ToString());
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
                        string delete = "DELETE FROM storage WHERE ID = @id";
                        cmd.CommandText = delete;
                        cmd.Parameters.AddWithValue("@id", id.ToString());
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

        public static List<Storage> GetStorage()
        {
            MySqlConnection conn = null;
            List<Storage> storageList = new List<Storage>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = "SELECT * FROM storage";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                Storage item = new Storage(id);
                                storageList.Add(item);
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
            return storageList;
        }
    }
}
