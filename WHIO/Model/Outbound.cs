using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Warehouse_IO.Chart;
using Warehouse_IO.View.In_Out_ActivityForm;

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
        public Outbound(string invoiceNo, DateTime deliveryDate, Supplier supplier, bool isinter,string detail,bool iscomplete) : base(invoiceNo, deliveryDate, supplier, isinter,detail,iscomplete) { }

        //Method only for Outbound (not in Transport)
        public static List<OutboundActivity> GetOutboundList()
        {
            MySqlConnection conn = null;
            List<OutboundActivity> outboundList = new List<OutboundActivity>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
SELECT
  o.DeliveryDate,
  o.InvoiceNo,
  c.Name AS Customer,
  GROUP_CONCAT(DISTINCT dp.Name SEPARATOR ', ') AS DeliveryPlaces,
  GROUP_CONCAT(DISTINCT CONCAT(t.Name, ' (', ot.Quantity, ')') SEPARATOR ', ') AS Trucks,
  o.Detail,
  o.IsInter,
  o.ID AS OutboundID,
  o.IsComplete,
  (SELECT SUM(d.M3 * oq.Quantity)
   FROM outboundquantityofproductlist oq
   JOIN product p ON oq.ProductID = p.ID
   JOIN dimension d ON p.DimensionID = d.ID
   WHERE oq.OutboundID = o.ID) AS M3
FROM
  outbound o
LEFT JOIN
  supplier c ON o.SupplierID = c.ID
LEFT JOIN
  outbounddeliveryplace odp ON odp.OutboundID = o.ID
LEFT JOIN
  deliveryplace dp ON odp.DeliveryPlaceID = dp.ID
LEFT JOIN
  outboundtruck ot ON ot.OutboundID = o.ID
LEFT JOIN
  truck t ON ot.TruckID = t.ID
GROUP BY
  o.DeliveryDate,
  o.InvoiceNo,
  c.Name,
  o.Detail,
  o.IsInter,
  o.ID,
  o.IsComplete
ORDER BY
  o.DeliveryDate DESC
LIMIT
  300;

                    ";

                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string invoice = reader.GetString(reader.GetOrdinal("InvoiceNo"));
                            string customer = reader.GetString(reader.GetOrdinal("Customer"));
                            string deliveryplace = reader.GetString(reader.GetOrdinal("DeliveryPlaces"));
                            string truck = reader.GetString(reader.GetOrdinal("trucks"));
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
                            bool export = reader.GetBoolean(reader.GetOrdinal("IsInter"));
                            int outboundid = reader.GetInt32(reader.GetOrdinal("OutboundID"));
                            bool iscom = reader.GetBoolean(reader.GetOrdinal("IsComplete"));
                            double m3 = reader.GetDouble(reader.GetOrdinal("M3"));

                            outboundList.Add(new OutboundActivity(date, invoice, customer, deliveryplace, truck, detail, export, outboundid,iscom, m3));
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

        public static List<OutBoundTruckForChart> GetTruckOutboundList()
        {
            MySqlConnection conn = null;
            List<OutBoundTruckForChart> outboundList = new List<OutBoundTruckForChart>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string updateArrayList = @"
                    SELECT o.DeliveryDate, t.Name AS TruckName, ot.Quantity
                    FROM outbound AS o
                    INNER JOIN outboundtruck AS ot ON o.ID = ot.OutboundID
                    INNER JOIN truck AS t ON ot.TruckID = t.ID
                    WHERE t.ID IN (12, 13, 14, 15, 16)
                    ORDER BY
                    o.DeliveryDate DESC;
                    ";
                    cmd.CommandText = updateArrayList;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(reader.GetOrdinal("DeliveryDate"));
                            string typename = reader.GetString(reader.GetOrdinal("TruckName"));
                            int qty = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            outboundList.Add(new OutBoundTruckForChart(date, typename, qty));
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
                    string insert = $"INSERT INTO outbound (ID, InvoiceNo, DeliveryDate, SupplierID, IsInter, Detail, IsComplete) VALUES (NULL, @invoice, @date, @sup, @isinter, @detail, @iscom)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
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
                    string update = $"UPDATE outbound SET InvoiceNo = @invoice, DeliveryDate = @date, SupplierID = @sup, IsInter = @isinter, Detail = @detail, IsComplete = @iscom WHERE ID = @id ";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@invoice", InvoiceNo);
                    cmd.Parameters.AddWithValue("@date", DeliveryDate);
                    cmd.Parameters.AddWithValue("@sup", Supplier.ID);
                    cmd.Parameters.AddWithValue("@isinter", Inter);
                    cmd.Parameters.AddWithValue("@detail",Detail);
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
