using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class DimensionForGetList
    {
        public int ID { get; set; }
        public double M3 { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public string UnitOfVolume { get; set; }
        public string Details { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public DimensionForGetList(int id,double m3,double width, double length, double height,string unitofvo,string detail)
        {
            this.ID = id;
            this.M3 = m3;
            this.Width = width;
            this.Length = length;
            this.Height = height;
            this.UnitOfVolume = unitofvo;
            this.Details = detail;
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

                            dimensionlist.Add(new DimensionForGetList(id, m3, width, length, height, unitofvo, detail));
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
