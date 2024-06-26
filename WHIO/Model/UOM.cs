﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace Warehouse_IO.WHIO.Model
{
    class UOM
    {
        int id;
        public int ID { get { return id; } }
        double quantity;
        public double Quantity { get { return quantity; }set { quantity = value; } }
        UnitOfUOM unit;
        public UnitOfUOM Unit { get { return unit; }set { unit = value; } }
        Package package;
        public Package Package { get { return package; }set { package = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void CheckAndUpdateField(string columnName, string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM uom WHERE {columnName} = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                quantity = Convert.ToDouble(reader["Quantity"]);
                                package = new Package(reader["PackageName"].ToString());
                                unit = new UnitOfUOM(reader["UnitOfUOMName"].ToString());
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

        public UOM(int id)
        {
            CheckAndUpdateField("ID", id.ToString());
        }
        public UOM(double quantity,UnitOfUOM unit,Package package)
        {
            this.quantity = quantity;
            this.unit = unit;
            this.package = package;
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
                        string insert = "INSERT INTO uom (ID, Quantity, PackageName, UnitOfUOMName) VALUES (NULL, @quantity, @package, @unitofuom)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@package", package.Name);
                        cmd.Parameters.AddWithValue("@unitofuom", unit.Name);
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
                        string update = "UPDATE uom SET Quantity = @quantity, PackageName = @package, UnitOfUOMName = @unitofuom WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@package", package.Name);
                        cmd.Parameters.AddWithValue("@unitofuom", unit.Name);
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
                        string delete = "DELETE FROM uom WHERE ID = @id";
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

        public static List<UOM> GetUOMList()
        {
            MySqlConnection conn = null;
            List<UOM> uomlist = new List<UOM>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = "SELECT * FROM uom";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                UOM item = new UOM(id);
                                uomlist.Add(item);
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
            return uomlist;
        }
    }
}
