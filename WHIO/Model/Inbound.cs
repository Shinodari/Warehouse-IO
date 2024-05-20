using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.Chart;
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
        public Inbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, Storage storage, bool isinter,string detail,bool iscomplete) : base(invoiceNo, deliveryDate, supplier, isinter,detail, iscomplete)
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

                                inboundList.Add(new InboundActivity(date, invoice, customer, storage, truck, detail, import, storageId, inboundId,iscomplete, m3));
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

        public override bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO inbound (ID, InvoiceNo, DeliveryDate, SupplierID, StorageID, IsInter, Detail, IsComplete) VALUES (NULL, @invoice, @date, @sup, @sto, @isinter, @detail, @iscom)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("detail", Detail);
                    cmd.Parameters.AddWithValue("@iscom", IsComplete);
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
                    string update = $"UPDATE inbound SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, StorageID = @sto, IsInter = @isinter, Detail = @detail, IsComplete = @iscom WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", Storage.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("@detail", Detail);
                    cmd.Parameters.AddWithValue("@iscom", IsComplete);
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
