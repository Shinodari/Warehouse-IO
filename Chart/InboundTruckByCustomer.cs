using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Chart
{
    class InboundTruckByCustomer
    {
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public InboundTruckByCustomer(DateTime date, string typename, int qty)
        {
            this.Date = date;
            this.TypeName = typename;
            this.Quantity = qty;
        }

        public static List<InboundTruckByCustomer> GetTruckInboundListByCustomer(string customerName)
        {
            MySqlConnection conn = null;
            List<InboundTruckByCustomer> truckinboundlist = new List<InboundTruckByCustomer>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT i.DeliveryDate, c.Name AS CustomerName, t.Name AS TruckName, it.Quantity
                    FROM inbound AS i
                    INNER JOIN inboundtruck AS it ON i.ID = it.InboundID
                    INNER JOIN truck AS t ON it.TruckID = t.ID
                    INNER JOIN supplier AS c ON i.SupplierID = c.ID
                    WHERE c.Name = @customerName
                    AND t.ID IN (12, 13)
                    ORDER BY i.DeliveryDate DESC;
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

                            truckinboundlist.Add(new InboundTruckByCustomer(date, trucktype, qty));
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
