using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.View.Dimensions.DimensionSource;

namespace Warehouse_IO.WHIO.Model
{
    public class Dimension
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; } set{ name = value; } }
        double width;
        public double Width { get { return width; }set { width = value; } }
        double length;
        public double Length { get { return length; }set { length = value; } }
        double height;
        public double Height { get { return height; }set { height = value; } }
        UnitOfDimension unit;
        public UnitOfDimension Unit { get { return unit; }set { unit = value; } }
        double m3;
        public double M3 { get { return m3; }set { m3 = value; } }

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
                            name = reader["Name"].ToString();
                            width = Convert.ToDouble(reader["Width"]);
                            length = Convert.ToDouble(reader["Length"]);
                            height = Convert.ToDouble(reader["Height"]);
                            unit = new UnitOfDimension (reader["UnitOfDimensionName"].ToString());
                            m3 = Convert.ToDouble(reader["M3"]);
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
        public Dimension(double width,double length,double height, UnitOfDimension unit, string name = null)
        {
            this.name = name;
            this.width = width;
            this.length = length;
            this.height = height;
            this.unit = unit;
            this.m3 = (width * length * height) / 1000000;
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
                    string insert = "INSERT INTO dimension (ID, Name, Width, Length, Height, UnitOfDimensionName, M3) VALUES (NULL, @name, @width, @length, @height, @unit, @m3)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@width", width);
                    cmd.Parameters.AddWithValue("@length", length);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@unit", unit.Name);
                    cmd.Parameters.AddWithValue("@m3", m3);
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
            this.m3 = (width * length * height) / 1000000;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string update = "UPDATE dimension SET Name = @name, Width = @width, Length = @length, Height = @height, UnitOfDimensionName = @unit, M3 = @m3 WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@width", width);
                    cmd.Parameters.AddWithValue("@length", length);
                    cmd.Parameters.AddWithValue("@height", height);
                    cmd.Parameters.AddWithValue("@unit", unit.Name);
                    cmd.Parameters.AddWithValue("@m3", m3);
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

        public static List<DimensionForGetList> GetDimensionList()
        {
            MySqlConnection conn = null;
            List<DimensionForGetList> dimensionlist = new List<DimensionForGetList>();
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
                            double m3 = Convert.ToDouble(reader["M3"]);
                            double width = Convert.ToDouble(reader["Width"]);
                            double length = Convert.ToDouble(reader["Length"]);
                            double height = Convert.ToDouble(reader["Height"]);
                            string unitofvo = reader["UnitOfDimensionName"].ToString();
                            string detail = reader["Name"].ToString();

                            dimensionlist.Add(new DimensionForGetList(id,m3,width,length,height,unitofvo,detail));
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
