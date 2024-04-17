using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Warehouse_IO.WHIO.Model
{
    class Department
    {
        int id;
        public int ID { get; }
        string name;
        public string Name { get; set; }
        ArrayList storage = new ArrayList(Storage.GetStorage());

        static string connstr = Settings.Default.CONNECTION_STRING;
        private void CheckAndUpdateField(string columnName, string value)
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
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
                    conn.Close();
                }
            }
            catch (MySqlException e) { }
        }
        public Department(int id)
        {
            this.CheckAndUpdateField("ID",id.ToString());
        }
        public Department(string name)
        {
            Name = name;
        }
        //Constructor for use in GetDepartment()
        public Department(int id, string name) { ID = id; Name = name; }

        public int GetID() { return ID; }
        public string GetName() { return Name; }
        public ArrayList GetStorage()
        {
            return storage;
        }

        public void SetName(string name) { this.name = name; }

        public bool Create()
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string insert = "INSERT INTO department (ID, Name) VALUES (NULL, @name)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        public bool Change()
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string update = "UPDATE department SET Name = @name WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        public bool Remove()
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string delete = "DELETE FROM department WHERE ID = @id";
                        cmd.CommandText = delete;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public bool AddStorage(string storageName)
        {
            Storage sto = new Storage(storageName);
            bool succ = sto.Create();
            if (succ) { return true; }
            else return false;
        }
        public bool ChangeStorageName(string newStorageName)
        {
            Storage sto = new Storage(newStorageName);
            bool succ = sto.Change();
            if (succ) { return true; }
            else return false;
        }
        public bool RemoveStorage(int storageID)
        {
            Storage sto = new Storage(storageID);
            bool succ = sto.Remove();
            if (succ) { return true; }
            else return false;
        }

        public static ArrayList GetDepartmentList()
        {
            ArrayList departmentList = new ArrayList();
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string updateArrayList = $"SELECT * FROM department";
                        cmd.CommandText = updateArrayList;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ID"]);
                                string name = reader["Name"].ToString();
                                Department item = new Department(id, name);
                                departmentList.Add(item);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (MySqlException e) { }
            return departmentList;
        }
    }
}
