using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Dimension
    {
        int id;
        public int ID { get { return id; } }
        double width;
        public double Width { get { return width; }set { width = value; } }
        double length;
        public double Length { get { return length; }set { length = value; } }
        double height;
        public double Height { get { return height; }set { height = value; } }
        UnitOfDimension unit;
        public UnitOfDimension Unit { get { return unit; }set { unit = value; } }

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
                    string check = $"SELECT * FROM dimension WHERE {columnName} = @value";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@value", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            width = Convert.ToDouble(reader["Width"]);
                            length = Convert.ToDouble(reader["Length"]);
                            height = Convert.ToDouble(reader["Height"]);
                            unit = new UnitOfDimension (reader["UnitOfDimensionName"].ToString());
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

        public Dimension(int id) { this.CheckAndUpdateField("ID", id.ToString()); }
        public Dimension(double width,double length,double height, UnitOfDimension unit)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.unit = unit;
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
                    string insert = "INSERT INTO dimension (ID, Width, Length, Height, UnitOfDimensionName) VALUES (NULL, @width, @length, @height, @unit)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@width", width);
                    cmd.Parameters.AddWithValue("@length", length);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@unit", unit.Name);
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
                    string update = "UPDATE dimension SET Width = @width, Length = @length, Height = @height, UnitOfDimensionName = @unit WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@width", width);
                    cmd.Parameters.AddWithValue("@length", length);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@unit", unit.Name);
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
                    string delete = "DELETE FROM dimension WHERE ID = @id";
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

        public static List<Dimension> GetDimensionList()
        {
            MySqlConnection conn = null;
            List<Dimension> dimensionlist = new List<Dimension>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM dimension";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            Dimension item = new Dimension(id);
                            dimensionlist.Add(item);
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
            return dimensionlist;
        }
    }
}
