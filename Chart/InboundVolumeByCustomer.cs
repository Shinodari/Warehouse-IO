using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Chart
{
    class InboundVolumeByCustomer
    {
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public double M3 { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public InboundVolumeByCustomer(DateTime date,string customer,double m3)
        {
            this.Date = date;
            this.Customer = customer;
            this.M3 = m3;
        }

        public static List<InboundVolumeByCustomer> GetInboundListByCustomer(string customerName)
        {
            MySqlConnection conn = null;
            List<InboundVolumeByCustomer> inboundList = new List<InboundVolumeByCustomer>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT
                    i.DeliveryDate,
                    s.Name AS Customer,
                    (
                    SELECT SUM(d.M3 * iq.Quantity)
                    FROM inboundquantityofproductlist iq
                    JOIN product p ON iq.ProductID = p.ID
                    JOIN dimension d ON p.DimensionID = d.ID
                    WHERE iq.InboundID = i.ID
                    AND s.Name = @customerName
                    ) AS M3
                    FROM
                    inbound i
                    LEFT JOIN
                    supplier s ON i.SupplierID = s.ID
                    WHERE s.Name = @customerName
                    GROUP BY
                    i.DeliveryDate,
                    s.Name
                    ORDER BY
                    i.DeliveryDate DESC;
                    ";

                    cmd.CommandText = updateArrayList;
                    cmd.Parameters.AddWithValue("@customerName", customerName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date;
                            string customer;
                            double m3;
                            try
                            {
                                if (reader == null)
                                {
                                    Console.WriteLine("Reader object is null!");
                                    throw new NullReferenceException("Reader cannot be null");
                                }
                                date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                                customer = reader.GetString(reader.GetOrdinal("Customer"));
                                m3 = reader.GetDouble(reader.GetOrdinal("M3"));
                                inboundList.Add(new InboundVolumeByCustomer(date, customer, m3));
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("Unexpected null reference exception!");
                            }
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
            return inboundList;
        }
    }
}

