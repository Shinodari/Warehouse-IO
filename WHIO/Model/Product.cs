using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Product
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; }set { name = value; } }
        UOM uom;
        public UOM UOM { get { return uom; }set { uom = value; } }
        Dimension dimension;
        public Dimension Dimension { get { return dimension; }set { dimension = value; } }

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
                    string check = $"SELECT * FROM product WHERE {columnName} = @value";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@value", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            name = reader["Name"].ToString();
                            uom = new UOM(Convert.ToInt32(reader["UOMID"]));
                            dimension = new Dimension(Convert.ToInt32(reader["DimensionID"]));
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

        public Product(int id)
        {
            CheckAndUpdateField("ID", id.ToString());
        }
        public Product(string name,UOM uom,Dimension dimension)
        {
            this.name = name;
            this.uom = uom;
            this.dimension = dimension;
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
                    string insert = "INSERT INTO product (ID, Name, UOMID, DimensionID) VALUES (NULL, @name, @uom, @dimension)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@uom", uom.ID);
                    cmd.Parameters.AddWithValue("@dimension", dimension.ID);
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
                    string update = "UPDATE product SET Name = @name, UOMID = @uom, DimensionID = @dimension WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@uom", uom.ID);
                    cmd.Parameters.AddWithValue("@dimension", dimension.ID);
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
                    string delete = "DELETE FROM product WHERE ID = @id";
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

        public static List<Product> GetProductList()
        {
            MySqlConnection conn = null;
            List<Product> productList = new List<Product>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM product";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            Product item = new Product(id);
                            productList.Add(item);
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
            return productList;
        }
    }
}
