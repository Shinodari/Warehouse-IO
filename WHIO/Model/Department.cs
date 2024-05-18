using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using Warehouse_IO.View.DepartmentFormSource;

namespace Warehouse_IO.WHIO.Model
{
    public class Department
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; } set { name = value; } }
        List<Storage> storagelist;
        public List<Storage> StorageList { get { return storagelist; }set { storagelist = value; } }
        List<Deliveryplace> deliveryplacelist;
        public List<Deliveryplace> DeliveryplaceList { get { return deliveryplacelist; }set { deliveryplacelist = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;
        void getstoragelist()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string check = "SELECT StorageID FROM departmenthavestorage WHERE DepartmentID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int storageID = Convert.ToInt32(reader["StorageID"]);
                            Storage item = new Storage(storageID);
                            storagelist.Add(item);
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
                    string check = "SELECT DeliveryplaceID FROM departmenthavedeliveryplace WHERE DepartmentID = @id";
                    cmd.CommandText = check;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int deliveryID = Convert.ToInt32(reader["DeliveryplaceID"]);
                            Deliveryplace item = new Deliveryplace(deliveryID);
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
        void CheckAndUpdateField(string columnName, string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM department WHERE {columnName} = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                name = reader["Name"].ToString();
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
        public Department(int id)
        {
            storagelist = new List<Storage>();
            deliveryplacelist = new List<Deliveryplace>();
            this.CheckAndUpdateField("ID",id.ToString());
            getstoragelist();
            getdeliveryplacelist();
        }
        public Department(string name)
        {
            this.name = name;
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
                        string insert = "INSERT INTO department (ID, Name) VALUES (NULL, @name)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@name", name);
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
                        string update = "UPDATE department SET Name = @name WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", name);
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
                        string delete = "DELETE FROM department WHERE ID = @id";
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

        public bool AddStorage(Storage sto)
        {
            if (sto != null)
            {
                storagelist.Add(sto);
                return true;
            }
            else return false;
        }
        public bool RemoveStorage(Storage sto)
        {
            if (sto != null)
            {
                int removeCount = storagelist.RemoveAll(st => st.ID == sto.ID);
                return removeCount > 0;
            }
            else return false;
        }
        public bool UpdateStorage()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM departmenthavestorage WHERE DepartmentID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO departmenthavestorage (DepartmentID, StorageID) VALUES (@id, @sto)";
                    cmd.CommandText = insert;
                    foreach (Storage sto in storagelist)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sto", sto.ID);
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

        public bool AddDeliveryplace(Deliveryplace del)
        {
            if (del != null)
            {
                deliveryplacelist.Add(del);
                return true;
            }
            else return false;
        }
        public bool RemoveDeliveryplace(Deliveryplace del)
        {
            if (del != null)
            {
                int removeCount = deliveryplacelist.RemoveAll(dp => dp.ID == del.ID);
                return removeCount > 0;
            }
            return false;
        }
        public bool UpdateDeliveryplace()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM departmenthavedeliveryplace WHERE DepartmentID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    string insert = $"INSERT INTO departmenthavedeliveryplace (DepartmentID, DeliveryplaceID) VALUES (@id, @del)";
                    cmd.CommandText = insert;
                    foreach (Deliveryplace del in deliveryplacelist)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@del", del.ID);
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

        public static List<DepartmentForGetList> GetDepartmentList()
        {
            MySqlConnection conn = null;
            List<DepartmentForGetList> departmentList = new List<DepartmentForGetList>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                    string updateArrayList = @"
                        SELECT
                        d.ID AS DepartmentID,
                        d.Name AS DepartmentName,
                        GROUP_CONCAT(DISTINCT s.Name SEPARATOR ', ') AS StorageNames
                        FROM department d
                        LEFT JOIN departmenthavestorage ds ON ds.DepartmentID = d.ID
                        LEFT JOIN storage s ON ds.StorageID = s.ID
                        GROUP BY d.ID, d.Name;";

                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["DepartmentID"]);
                                string name = reader["DepartmentName"].ToString();
                                string dephaves = reader["StorageNames"].ToString();
                                departmentList.Add(new DepartmentForGetList(id,name,dephaves));
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
            return departmentList;
        }

    }
}
