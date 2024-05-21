using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class InboundActivity
    {
        public DateTime Date { get; set; }
        public string Invoice { get; set; }
        public string Customer { get; set; }
        public string Storage { get; set; }
        public string Truck { get; set; }
        public string Details { get; set; }
        public bool Import { get; set; }
        public int StorageID { get; set; }
        public int InboundID { get; set; }
        public bool Iscomplete { get; set; }
        public double M3 { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public InboundActivity(DateTime date, string invoice, string customer, string storage,string truck,string detail,bool import,int storageid,int inboundid,bool complete,double m3)
        {
            this.Date = date;
            this.Invoice = invoice;
            this.Customer = customer;
            this.Storage = storage;
            this.Truck = truck;
            this.Details = detail;
            this.Import = import;
            this.StorageID = storageid;
            this.InboundID = inboundid;
            this.Iscomplete = complete;
            this.M3 = m3;
        }

        public static List<InboundActivity> GetInboundList()
        {
            MySqlConnection conn = null;
            List<InboundActivity> inboundList = new List<InboundActivity>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT
                    i.DeliveryDate,
                    i.InvoiceNo,
                    c.Name AS Customer,
                    s.Name AS Storage,
                    GROUP_CONCAT(CONCAT(t.Name, ' (', it.Quantity, ')') SEPARATOR ', ') AS Truck,
                    i.Detail,
                    i.IsInter,
                    s.ID AS StorageID,
                    i.ID AS InboundID,
                    i.IsComplete,
                    (SELECT SUM(d.M3 * iq.Quantity)
                    FROM inboundquantityofproductlist iq
                    JOIN product p ON iq.ProductID = p.ID
                    JOIN dimension d ON p.DimensionID = d.ID
                    WHERE iq.InboundID = i.ID) AS M3
                    FROM
                    inbound i
                    LEFT JOIN
                    supplier c ON i.SupplierID = c.ID
                    LEFT JOIN
                    storage s ON i.StorageID = s.ID
                    LEFT JOIN
                    inboundtruck it ON it.InboundID = i.ID
                    LEFT JOIN
                    truck t ON it.TruckID = t.id
                    GROUP BY
                    i.DeliveryDate,
                    i.InvoiceNo,
                    c.Name,
                    s.Name,
                    i.Detail,
                    i.IsInter,
                    s.ID,
                    i.ID,
                    i.IsComplete
                    ORDER BY
                    i.DeliveryDate DESC
                    LIMIT
                    300;
                    ";

                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date;
                            string invoice;
                            string customer;
                            string storage;
                            string truck;
                            string detail;
                            bool import;
                            int storageId;
                            int inboundId;
                            bool iscomplete;
                            double m3;

                            try
                            {
                                if (reader == null)
                                {
                                    Console.WriteLine("Reader object is null!");
                                    throw new NullReferenceException("Reader cannot be null");
                                }
                                date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                                invoice = reader.GetString(reader.GetOrdinal("InvoiceNo"));
                                customer = reader.GetString(reader.GetOrdinal("Customer"));
                                storage = reader.GetString(reader.GetOrdinal("Storage"));

                                // Check for null before calling GetString for truck
                                if (!reader.IsDBNull(reader.GetOrdinal("Truck")))
                                {
                                    truck = reader.GetString(reader.GetOrdinal("Truck"));
                                }
                                else
                                {
                                    truck = "";
                                }
                                if (!reader.IsDBNull(reader.GetOrdinal("Detail")))
                                {
                                    detail = reader.GetString(reader.GetOrdinal("Detail"));
                                }
                                else
                                {
                                    detail = "";
                                }
                                import = reader.GetBoolean(reader.GetOrdinal("IsInter"));
                                storageId = reader.GetInt32(reader.GetOrdinal("StorageID"));
                                inboundId = reader.GetInt32(reader.GetOrdinal("InboundID"));
                                iscomplete = reader.GetBoolean(reader.GetOrdinal("IsComplete"));
                                m3 = reader.GetDouble(reader.GetOrdinal("M3"));

                                inboundList.Add(new InboundActivity(date, invoice, customer, storage, truck, detail, import, storageId, inboundId, iscomplete, m3));
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
