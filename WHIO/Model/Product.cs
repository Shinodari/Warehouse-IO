using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.View.ProductSource;

namespace Warehouse_IO.WHIO.Model
{
    public class Product
    {
        string id;
        public string ID { get { return id; }set { id = value; } }
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
                            id = reader["ID"].ToString();
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

        public Product(string id)
        {
            CheckAndUpdateField("ID", id.ToString());
        }
        public Product(string id,string name,UOM uom,Dimension dimension)
        {
            this.id = id;
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
                    string insert = "INSERT INTO product (ID, Name, UOMID, DimensionID) VALUES (@id, @name, @uom, @dimension)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@id", id);
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

        public static List<ProductForDataGridView> GetAdjustedProductList()
        {
            MySqlConnection conn = null;
            List<ProductForDataGridView> adjustedproductlist = new List<ProductForDataGridView>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string query = @"
                    SELECT 
                    p.ID,
                    p.Name,
                    d.M3,
                    u.Quantity,
                    u.UnitOfUOMName,
                    u.PackageName
                    FROM
                    product p
                    LEFT JOIN
                    dimension d ON p.DimensionID = d.ID
                    LEFT JOIN
                    uom u ON p.UOMID = u.ID";

                    cmd.CommandText = query;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["ID"].ToString();
                            string name = reader["Name"].ToString();
                            double? m3 = reader["M3"] != DBNull.Value ? (double?)Convert.ToDouble(reader["M3"]) : null;
                            double? weight = reader["Quantity"] != DBNull.Value ? (double?)Convert.ToDouble(reader["Quantity"]) : null;
                            string uomname = reader["UnitOfUOMName"].ToString();
                            string packname = reader["PackageName"].ToString();

                            adjustedproductlist.Add(new ProductForDataGridView(id, name, m3, weight, uomname, packname));
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
            return adjustedproductlist;
        }

        public int GetQuantity(double kgs)
        {
            int uomQuantity = (int)uom.Quantity;
            return (int) Math.Ceiling(kgs/ uomQuantity);
        }
    }
}
