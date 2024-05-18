using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.View.In_Out_ActivityForm;

namespace Warehouse_IO.WHIO.Model
{
    class Inbound : Transport
    {
        Storage storage;
        public Storage Storage { get { return storage; } set { storage = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public Inbound(int id,Storage sto) : base(id)
        {
            this.storage = sto;
            if (InvoiceNo != null)
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
                    string check = "SELECT * FROM inboundtruck WHERE InboundID = @id";
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
                    string check = $"SELECT * FROM inboundquantityofproductlist WHERE InboundID = @id";
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
        public Inbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, Storage storage, bool isinter,string detail) : base(invoiceNo, deliveryDate, supplier, isinter,detail)
        {
            this.storage = storage;
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
    i.ID AS InboundID
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
    i.ID
ORDER BY
    i.DeliveryDate DESC
LIMIT
    50;
                    ";
                    
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string invoice = reader.GetString(reader.GetOrdinal("InvoiceNo"));
                            string customer = reader.GetString(reader.GetOrdinal("Customer"));
                            string storage = reader.GetString(reader.GetOrdinal("Storage"));
                            string truck = reader.GetString(reader.GetOrdinal("Truck"));
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
                            bool import = reader.GetBoolean(reader.GetOrdinal("IsInter"));
                            int storageId = reader.GetInt32(reader.GetOrdinal("StorageID"));
                            int inboundId = reader.GetInt32(reader.GetOrdinal("InboundID"));

                            inboundList.Add(new InboundActivity(date,invoice,customer,storage, truck, detail,import,storageId,inboundId));
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

        public override bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO inbound (ID, InvoiceNo, DeliveryDate, SupplierID, StorageID, IsInter, Detail) VALUES (NULL, @invoice, @date, @sup, @sto, @isinter, @detail)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
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
                    string update = $"UPDATE inbound SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, StorageID = @sto, IsInter = @isinter, Detail = @detail WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("@detail", Detail);
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
                    string delete = $"DELETE FROM inbound WHERE ID = @id";
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

        public override bool UpdateProduct()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM inboundquantityofproductlist WHERE InboundID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO inboundquantityofproductlist (ProductID, InboundID, Quantity) VALUES (@pro, @out, @qty)";
                    cmd.CommandText = insert;
                    foreach (KeyValuePair<Product, int> kvp in QuantityOfProductList)
                    {
                        Product pro = kvp.Key;
                        int qty = kvp.Value;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@pro", pro.ID);
                        cmd.Parameters.AddWithValue("@out", this.ID);
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
                    string delete = "DELETE FROM inboundtruck WHERE InboundID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO inboundtruck (InboundID, TruckID, Quantity) VALUES (@id, @truck, @qty)";
                    cmd.CommandText = insert;
                    foreach (KeyValuePair<Truck, int> kvp in TruckQuantityPerShipmentList)
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
    }
}
