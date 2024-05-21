using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    class OutboundActivity
    {
        public DateTime Date { get; set; }
        public string Invoice { get; set; }
        public string Customer { get; set; }
        public string DeliveryPlace { get; set; }
        public string Truck { get; set; }
        public string Details { get; set; }
        public bool Export { get; set; }
        public int OutboundID { get; set; }
        public bool Iscomplete { get; set; }
        public double M3 { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public OutboundActivity(DateTime date, string invoice, string customer, string deliveryplace, string truck, string detail,bool isinter, int outboundid,bool iscomplete,double m3)
        {
            this.Date = date;
            this.Invoice = invoice;
            this.Customer = customer;
            this.DeliveryPlace = deliveryplace;
            this.Truck = truck;
            this.Details = detail;
            this.Export = isinter;
            this.OutboundID = outboundid;
            this.Iscomplete = iscomplete;
            this.M3 = m3;
        }

        public static List<OutboundActivity> GetOutboundList()
        {
            MySqlConnection conn = null;
            List<OutboundActivity> outboundList = new List<OutboundActivity>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
SELECT
  o.DeliveryDate,
  o.InvoiceNo,
  c.Name AS Customer,
  GROUP_CONCAT(DISTINCT dp.Name SEPARATOR ', ') AS DeliveryPlaces,
  GROUP_CONCAT(DISTINCT CONCAT(t.Name, ' (', ot.Quantity, ')') SEPARATOR ', ') AS Trucks,
  o.Detail,
  o.IsInter,
  o.ID AS OutboundID,
  o.IsComplete,
  (SELECT SUM(d.M3 * oq.Quantity)
   FROM outboundquantityofproductlist oq
   JOIN product p ON oq.ProductID = p.ID
   JOIN dimension d ON p.DimensionID = d.ID
   WHERE oq.OutboundID = o.ID) AS M3
FROM
  outbound o
LEFT JOIN
  supplier c ON o.SupplierID = c.ID
LEFT JOIN
  outbounddeliveryplace odp ON odp.OutboundID = o.ID
LEFT JOIN
  deliveryplace dp ON odp.DeliveryPlaceID = dp.ID
LEFT JOIN
  outboundtruck ot ON ot.OutboundID = o.ID
LEFT JOIN
  truck t ON ot.TruckID = t.ID
GROUP BY
  o.DeliveryDate,
  o.InvoiceNo,
  c.Name,
  o.Detail,
  o.IsInter,
  o.ID,
  o.IsComplete
ORDER BY
  o.DeliveryDate DESC
LIMIT
  300;

                    ";

                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string invoice = reader.GetString(reader.GetOrdinal("InvoiceNo"));
                            string customer = reader.GetString(reader.GetOrdinal("Customer"));
                            string deliveryplace = reader.GetString(reader.GetOrdinal("DeliveryPlaces"));
                            string truck = reader.GetString(reader.GetOrdinal("trucks"));
                            string detail;
                            object detailObj = reader?.GetValue(reader.GetOrdinal("Detail"));
                            if (detailObj != DBNull.Value && detailObj != null)
                            {
                                detail = detailObj.ToString();
                            }
                            else
                            {
                                detail = "-";
                            }
                            bool export = reader.GetBoolean(reader.GetOrdinal("IsInter"));
                            int outboundid = reader.GetInt32(reader.GetOrdinal("OutboundID"));
                            bool iscom = reader.GetBoolean(reader.GetOrdinal("IsComplete"));
                            double m3 = reader.GetDouble(reader.GetOrdinal("M3"));

                            outboundList.Add(new OutboundActivity(date, invoice, customer, deliveryplace, truck, detail, export, outboundid, iscom, m3));
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
            return outboundList;
        }
    }
}
