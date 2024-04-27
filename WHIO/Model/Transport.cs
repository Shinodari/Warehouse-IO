using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.WHIO.Model
{
    abstract class Transport
    {
        int id;
        public int ID { get { return id; } }
        string invoiceno;
        public string InvoiceNo { get { return invoiceno; } set { invoiceno = value; } }
        DateTime deliverydate;
        public DateTime DeliveryDate { get { return deliverydate; } set { deliverydate = value; } }
        Supplier supplier;
        public Supplier Supplier { get { return supplier; } set { supplier = value; } }
        List<Truck> trucklist;
        public List<Truck> TruckList { get { return trucklist; }set { trucklist = value; } }
        Storage storage;
        public Storage Storage { get { return storage; } }
        Dictionary <Product,int> quantityofproductlist;
        public Dictionary<Product, int> QuantityOfProductList { get { return quantityofproductlist; }set { quantityofproductlist = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        string GetTableNameFromClassName()
        {
            string className = GetType().Name;
            string tableName = className.ToLower();
            return tableName;
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
                    string tableName = GetTableNameFromClassName();
                        string check = $"SELECT * FROM {tableName} WHERE ID = @value";
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
            CheckAndUpdateField(id.ToString());
            if(invoiceno != null)
            {
                quantityofproductlist = new Dictionary<Product, int>();
                trucklist = new List<Truck>();
            }
        }
        public Transport(string invoiceNo,DateTime deliveryDate,Supplier supplier,Storage storage)
        {
            invoiceno = invoiceNo;
            deliverydate = deliveryDate;
            this.supplier = supplier;
            this.storage = storage;
        }

        public abstract bool Create();
        public abstract bool Change();
        public abstract bool Remove();

        public bool AddTruck(Truck truck)
        {
            if (truck != null)
            {
                trucklist.Add(truck);
                return true;
            }
            else  return false;
        }
        public bool RemoveTruck(Truck truck)
        {
            if (truck != null)
            {
                trucklist.Remove(truck);
                return true;
            }
            else return false;
        }

        public bool AddProduct(Product pro,int qty)
        {
            if (pro != null)
            {
                quantityofproductlist.Add(pro, qty);
                return true;
            }
            else return false;
        }
        public bool RemoveProduct(Product pro)
        {
            if (pro != null)
            {
                quantityofproductlist.Remove(pro);
                return true;
            }
            else return false;
        }
        public bool ChangeQuantityOfProduct(Product pro,int qty)
        {
            if (pro != null && quantityofproductlist.ContainsKey(pro))
            {
                quantityofproductlist[pro] = qty;
                return true;
            }
            else return false;
        }

        public abstract bool UpdateTruck();
        public abstract bool UpdateProduct();
        
    }
}
