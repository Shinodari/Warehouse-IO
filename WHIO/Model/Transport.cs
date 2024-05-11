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

        private Dictionary<Truck, int> truckquantitypershipmentlist = new Dictionary<Truck, int>(new TruckEqualityComparer());
        public Dictionary<Truck, int> TruckQuantityPerShipmentList { get { return truckquantitypershipmentlist; }set { truckquantitypershipmentlist = value; } }

        Dictionary<Product, int> quantityofproductlist = new Dictionary<Product, int>(new ProductEqualityComparer());
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
            quantityofproductlist = new Dictionary<Product, int>(new ProductEqualityComparer());
            truckquantitypershipmentlist = new Dictionary<Truck, int>(new TruckEqualityComparer());
            CheckAndUpdateField(id.ToString());
        }
        public Transport(string invoiceNo,DateTime deliveryDate,Supplier supplier)
        {
            quantityofproductlist = new Dictionary<Product, int>(new ProductEqualityComparer());
            truckquantitypershipmentlist = new Dictionary<Truck, int>(new TruckEqualityComparer());
            invoiceno = invoiceNo;
            deliverydate = deliveryDate;
            this.supplier = supplier;
        }

        public abstract bool Create();
        public abstract bool Change();
        public abstract bool Remove();

        public bool AddTruck(Truck truck,int qty)
        {
            if (truck != null)
            {
                truckquantitypershipmentlist.Add(truck,qty);
                return true;
            }
            else  return false;
        }
        public bool RemoveTruck(Truck truck)
        {
            if (truck != null)
            {
                truckquantitypershipmentlist.Remove(truck);
                return true;
            }
            else return false;
        }
        public bool ChangeQuantityOfTruck(Truck truck,int qty)
        {
            if (truck != null && truckquantitypershipmentlist.ContainsKey(truck))
            {
                truckquantitypershipmentlist[truck] = qty;
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

        public class TruckEqualityComparer : IEqualityComparer<Truck>
        {
            public bool Equals(Truck x, Truck y)
            {
                if (x == null || y == null)
                {
                    return false;
                }
                return x.ID == y.ID;
            }
            public int GetHashCode(Truck obj)
            {
                return obj.ID.GetHashCode();
            }
        }
        public class ProductEqualityComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                if (x == null || y == null)
                {
                    return false;
                }
                return x.ID == y.ID;
            }
            public int GetHashCode(Product obj)
            {
                return obj.ID.GetHashCode();
            }
        }
    }
}
