
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class ProductForDataGridView
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public double? M3 { get; set; }
        public double? Weight { get; set; }
        public string Unit { get; set; }
        public string Package { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public ProductForDataGridView(string name, string detail, double? m3, double? weight, string unit, string package)
        {
            this.Name = name;
            this.Details = detail;
            this.M3 = m3;
            this.Weight = weight;
            this.Unit = unit;
            this.Package = package;
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
    }
}
