using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Chart
{
    public class InboundTruckForChart
    {
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public InboundTruckForChart(DateTime date,string typename,int qty)
        {
            this.Date = date;
            this.TypeName = typename;
            this.Quantity = qty;
        }

        public static List<InboundTruckForChart> GetTruckInboundList()
        {
            MySqlConnection conn = null;
            List<InboundTruckForChart> truckinboundlist = new List<InboundTruckForChart>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT i.DeliveryDate, t.Name AS TruckName, it.Quantity
                    FROM inbound AS i
                    INNER JOIN inboundtruck AS it ON i.ID = it.InboundID
                    INNER JOIN truck AS t ON it.TruckID = t.ID
                    WHERE t.ID IN (12, 13)
                    ORDER BY
                    i.DeliveryDate DESC;
                    ";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string trucktype = reader.GetString(reader.GetOrdinal("TruckName"));
                            int qty = reader.GetInt32(reader.GetOrdinal("Quantity"));

                            truckinboundlist.Add(new InboundTruckForChart(date, trucktype, qty));
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
