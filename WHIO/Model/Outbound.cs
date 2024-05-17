using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Outbound : Transport
    {
        List<Deliveryplace> deliveryplacelist;
        public List<Deliveryplace> DeliveryplaceList { get{return deliveryplacelist; } set { deliveryplacelist = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public Outbound(int id) : base(id)
        {
            if(InvoiceNo != null)
            {
                deliveryplacelist = new List<Deliveryplace>();
                gettrucklist();
                getquantityofproductlist();
                getdeliveryplacelist();
            }
        }

        //Method only for Outbound (not in Transport)
        void gettrucklist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = "SELECT * FROM outboundtruck WHERE OutboundID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int truck = Convert.ToInt32(reader["TruckID"]);
                            Truck item = new Truck(truck);
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            TruckQuantityPerShipmentList.Add(item,qty);
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
                            string product = reader["ProductID"].ToString();
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
        void getdeliveryplacelist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = $"SELECT * FROM outbounddeliveryplace WHERE OutboundID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int deliveryPlace = Convert.ToInt32(reader["DeliveryplaceID"]);
                            Deliveryplace item = new Deliveryplace(deliveryPlace);
                            deliveryplacelist.Add(item);
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
        public Outbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, bool isinter,string detail) : base(invoiceNo, deliveryDate, supplier, isinter,detail) { }

        //Method only for Outbound (not in Transport)
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
                    string insert = $"INSERT INTO outbound (ID, InvoiceNo, DeliveryDate, SupplierID, IsInter, Detail) VALUES (NULL, @invoice, @date, @sup, @isinter, @detail)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("detail", Detail);
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
                    string update = $"UPDATE outbound SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, IsInter = @isinter, Detail = @detail WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("@detail",Detail);
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
                    string delete = $"DELETE FROM outbound WHERE ID = @id";
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

        //Method only for Outbound (not in Transport)
        public bool UpdateDeliveryplace()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM outbounddeliveryplace WHERE OutboundID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO outbounddeliveryplace (OutboundID, DeliveryplaceID) VALUES (@id, @deliver)";
                    cmd.CommandText = insert;
                    foreach (Deliveryplace delivery in deliveryplacelist)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@deliver", delivery.ID);
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
                    foreach (KeyValuePair<Product, int> kvp in QuantityOfProductList)
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

                    string insert = $"INSERT INTO outboundtruck (OutboundID, TruckID, Quantity) VALUES (@id, @truck, @qty)";
                    cmd.CommandText = insert;
                    foreach(KeyValuePair<Truck, int> kvp in TruckQuantityPerShipmentList)
                    {
                        Truck truck = kvp.Key;
                        int qty = kvp.Value;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@truck", truck.ID);
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

        //Method only for Outbound (not in Transport)
        public bool AddDeliveryPlace(Deliveryplace deliveryplace)
        {
            if (deliveryplace != null)
            {
                deliveryplacelist.Add(deliveryplace);
                return true;
            }
            else return false;
        }
        public bool RemoveDeliveryPlace(Deliveryplace deliveryplace)
        {
            if (deliveryplace != null)
            {
                int removeCount = deliveryplacelist.RemoveAll(dp => dp.ID == deliveryplace.ID);
                return removeCount > 0;
            }
            return false;
        }
      
    }
}
