using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.View.Transport.TruckFormSource;

namespace Warehouse_IO.WHIO.Model
{
    public class Truck
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; } set { name = value; } }
        string description;
        public string Description { get { return description; } set { description = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void CheckAndUpdateField(string columnName, string value)
        {

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM truck WHERE {columnName} = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                name = reader["Name"].ToString();
                                description = reader["Description"].ToString();
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

        public Truck(int id)
        {
            this.CheckAndUpdateField("ID", id.ToString());
        }
        public Truck(string name,string description = null)
        {
            this.name = name;
            this.description = description;
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
                        string insert = "INSERT INTO truck (ID, Name, Description) VALUES (NULL, @name, @description)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
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
                        string update = "UPDATE truck SET Name = @name, Description = @description WHERE ID = @id";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@id", id);
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
                        string delete = "DELETE FROM truck WHERE ID = @id";
                        cmd.CommandText = delete;
                        cmd.Parameters.AddWithValue("@id", id);
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

        public static List<TruckForGetList> GetTruckList()
        {
            MySqlConnection conn = null;
            List<TruckForGetList> truckList = new List<TruckForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = "SELECT * FROM truck";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                string name = reader["Name"].ToString();
                                string des = reader["Description"].ToString();
                                truckList.Add(new TruckForGetList(id,name,des));
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
            return truckList;
        }
    }
}
