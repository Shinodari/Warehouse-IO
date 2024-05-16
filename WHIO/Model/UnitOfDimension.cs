using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    public class UnitOfDimension : Unit
    {
        static string connstr = Settings.Default.CONNECTION_STRING;

        string newname;
        string oldname;
        public UnitOfDimension(string name) : base(name)
        {
            if (Name == null)
            {
                newname = name;
            }
            else oldname = Name;
        }

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

        public override bool Change()
        {
            if (Name != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string update = "UPDATE unitofdimension SET Name = @name WHERE Name = @oldname ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", Name);
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
            else return false;
        }

        public override bool Create()
        {
            if (newname != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string insert = "INSERT INTO unitofdimension (Name) VALUES (@name)";
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
            else return false;
        }

        public override bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM unitofdimension WHERE Name = @name";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@name", Name);
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
