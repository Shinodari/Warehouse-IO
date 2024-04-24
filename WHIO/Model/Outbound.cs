using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Outbound : Transport
    {
        static string connstr = Settings.Default.CONNECTION_STRING;

        public Outbound(int id) : base(id)
        {
            if(InvoiceNo != null)
            {
                gettrucklist();
                getquantityofproductlist();
            }
        }
        void gettrucklist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = "SELECT TruckID FROM outboundtruck WHERE OutboundID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int truck = Convert.ToInt32(reader["TruckID"]);
                            Truck item = new Truck(truck);
                            TruckList.Add(item);
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
        }
        void getquantityofproductlist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = $"SELECT * FROM outboundquantityofproductlist WHERE OutboundID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int product = Convert.ToInt32(reader["ProductID"]);
                            Product item = new Product(product);
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            QuantityOfProductList.Add(item, qty);
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
        }
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

        public override bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO outbound (ID, InvoiceNo, DeliveryDate, SupplierID, StorageID) VALUES (NULL, @invoice, @date, @sup, @sto)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public override bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string update = $"UPDATE outbound SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, StorageID = @sto WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public override bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = $"DELETE FROM outbond WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public override bool UpdateTruck()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM outboundtruck WHERE OutboundID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO outboundtruck (OutboundID, TruckID) VALUES (@id, @truck)";
                    cmd.CommandText = insert;
                    foreach(Truck t in TruckList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@truck", t.ID);
                        cmd.ExecuteNonQuery();
                    }               
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public override bool UpdateProduct()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM outboundquantityofproductlist WHERE OutboundID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO outboundquantityofproductlist (ProductID, OutboundID, Quantity) VALUES (@pro, @out, @qty)";
                    cmd.CommandText = insert;
                    foreach (KeyValuePair<Product,int> kvp in QuantityOfProductList)
                    {
                        Product pro = kvp.Key;
                        int qty = kvp.Value;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pro", pro.ID);
                        cmd.Parameters.AddWithValue("@out", ID);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
