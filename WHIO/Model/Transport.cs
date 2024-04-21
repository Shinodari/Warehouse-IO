using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    class Transport
    {
        protected int id;
        public int ID { get { return id; } }
        protected string invoiceno;
        public string InvoiceNo { get { return invoiceno; } set { invoiceno = value; } }
        protected DateTime deliverydate;
        public DateTime DeliveryDate { get { return deliverydate; } set { deliverydate = value; } }
        protected Supplier supplier;
        public Supplier Supplier { get { return supplier; } set { supplier = value; } }
        protected List<Truck> trucklist;
        public List<Truck> TruckList { get { return trucklist; } }
        protected Storage storage;
        public Storage Storage { get { return storage; } }
        protected Dictionary <Product,int> quantityofproductlist;
        public Dictionary<Product, int> QuantityOfProductList { get { return quantityofproductlist; }set { quantityofproductlist = value; } }

        protected virtual string TableName { get { return GetType().Name.ToLower(); } }
        protected virtual string TableName1 { get { return GetType().Name.ToLower()+"truck"; } }
        protected virtual string TableName2 { get { return GetType().Name.ToLower() + "quantityofproductlist"; } }
        protected virtual string ColumnName
        {
            get
            {
                string typeName = GetType().Name;
                string tableName = typeName.Substring(0, 1).ToUpper() + typeName.Substring(1).ToLower() + "ID";
                return tableName;
            }
        }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void gettrucklist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = $"SELECT TruckID FROM {TableName1} WHERE {ColumnName} = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int truck = Convert.ToInt32(reader["TruckID"]);
                            Truck item = new Truck(truck);
                            trucklist.Add(item);
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
                    string check = $"SELECT * FROM {TableName2} WHERE {ColumnName} = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int product = Convert.ToInt32(reader["ProductID"]);
                            Product item = new Product(product);
                            int qty = Convert.ToInt32(reader["Quantity"]);
                            quantityofproductlist.Add(item,qty);
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
        void CheckAndUpdateField(string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM {TableName} WHERE ID = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                invoiceno = reader["InvoiceNo"].ToString();
                                deliverydate = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                                supplier = new Supplier(Convert.ToInt32(reader["SupplierID"]));
                                storage = new Storage(Convert.ToInt32(reader["StorageID"]));
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

        public Transport(int id)
        {
            quantityofproductlist = new Dictionary<Product, int>();
            trucklist = new List<Truck>();
            CheckAndUpdateField(id.ToString());
            gettrucklist();
            getquantityofproductlist();
        }
        public Transport(string invoiceNo,DateTime deliveryDate,Supplier supplier,Storage storage)
        {
            invoiceno = invoiceNo;
            deliverydate = deliveryDate;
            this.supplier = supplier;
            this.storage = storage;
        }

        public bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO {TableName} (ID, InvoiceNo, DeliveryDate, SupplierID, StorageID) VALUES (NULL, @invoice, @date, @sup, @sto)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", invoiceno);
                    cmd.Parameters.AddWithValue("@date", deliverydate);
                    cmd.Parameters.AddWithValue("@sup", supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", storage.ID);
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
        public bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string update = $"UPDATE {TableName} SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, StorageID = @sto WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", invoiceno);
                    cmd.Parameters.AddWithValue("@date", deliverydate);
                    cmd.Parameters.AddWithValue("@sup", supplier.ID);
                    cmd.Parameters.AddWithValue("@sto", storage.ID);
                    cmd.Parameters.AddWithValue("@id", id);
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
        public bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = $"DELETE FROM {TableName} WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
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

        public bool AddTruck(Truck truckID)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO {TableName1} ({ColumnName}, TruckID) VALUES (@id, @truck)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@truck", truckID.ID);
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
        public bool RemoveTruck(Truck truckID)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = $"DELETE FROM {TableName1} WHERE {ColumnName} = @id AND TruckID = @truck";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@truck", truckID.ID);
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

        public bool AddProduct(Product productID,int qty)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = $"INSERT INTO {TableName2} (ProductID, {ColumnName}, Quantity) VALUES (@product, @id, @qty)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@product", productID.ID);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@qty", qty);
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
        public bool RemoveProduct(Product productID, int qty)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = $"DELETE FROM {TableName2} WHERE ProductID = @proID AND {ColumnName} = @id AND Quantity = @qty";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@proID", productID.ID);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@qty", qty);
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

    }
}
