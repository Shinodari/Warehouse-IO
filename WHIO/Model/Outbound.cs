using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Outbound : Transport
    {
        static string connstr = Settings.Default.CONNECTION_STRING;

        public Outbound(int id) : base(id) { }
        public Outbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, Storage storage) : base(invoiceNo, deliveryDate, supplier, storage) { }

        public static List<Outbound> GetOutboundList()
        {
            MySqlConnection conn = null;
            List<Outbound> outboundList = new List<Outbound>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM outbound";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            Outbound item = new Outbound(id);
                            outboundList.Add(item);
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
