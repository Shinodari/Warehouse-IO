using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Chart
{
    class OutboundTruckByCustomer
    {
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public OutboundTruckByCustomer(DateTime date, string typename, int qty)
        {
            this.Date = date;
            this.TypeName = typename;
            this.Quantity = qty;
        }

        public static List<OutboundTruckByCustomer> GetTruckOutboundListByCustomer(string customerName)
        {
            MySqlConnection conn = null;
            List<OutboundTruckByCustomer> truckinboundlist = new List<OutboundTruckByCustomer>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT o.DeliveryDate, c.Name AS CustomerName, t.Name AS TruckName, ot.Quantity
                    FROM outbound AS o
                    INNER JOIN outboundtruck AS ot ON o.ID = ot.OutboundID
                    INNER JOIN truck AS t ON ot.TruckID = t.ID
                    INNER JOIN supplier AS c ON o.SupplierID = c.ID
                    WHERE c.Name = @customerName
                    AND t.ID IN (12, 13, 14, 15, 16)
                    ORDER BY o.DeliveryDate DESC;
                    ";
                    cmd.CommandText = updateArrayList;
                    cmd.Parameters.AddWithValue("@customerName", customerName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string trucktype = reader.GetString(reader.GetOrdinal("TruckName"));
                            int qty = reader.GetInt32(reader.GetOrdinal("Quantity"));

                            truckinboundlist.Add(new OutboundTruckByCustomer(date, trucktype, qty));
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
            return truckinboundlist;
        }
    }
}
