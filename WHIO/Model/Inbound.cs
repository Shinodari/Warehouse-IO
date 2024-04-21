using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Inbound : Transport
    {
        static string connstr = Settings.Default.CONNECTION_STRING;

        public Inbound(int id) : base(id) { }
        public Inbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, Storage storage) : base(invoiceNo, deliveryDate, supplier, storage) { }

        public static List<Inbound> GetInboundList()
        {
            MySqlConnection conn = null;
            List<Inbound> inboundList = new List<Inbound>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = "SELECT * FROM inbound";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            Inbound item = new Inbound(id);
                            inboundList.Add(item);
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
