using System;
using System.Text;
using Warehouse_IO.WHIO.Model;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;

namespace Warehouse_IO.Authentication
{
    class User
    {
        int id;
        public int ID { get { return id; } }
        string username;
        public string Username { get { return username; } set { username = value; } }
        string password;
        private string Password;
        string fullname;
        public string FullName { get { return fullname; } set { fullname = value; } }
        string lastname;
        public string LastName { get { return lastname; } set { lastname = value; } }
        bool isadmin;
        public bool IsAdmin { get { return isadmin; } set { isadmin = value; } }
        Department department;
        public Department Department { get { return department; } set { department = value; } }

        string connstr = Settings.Default.CONNECTION_STRING;

        //this method for checking parameter to retrive database
        void CheckAndUpdateField(string columnName, string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                    {
                        string check = $"SELECT * FROM user WHERE {columnName} = @value";
                        cmd.CommandText = check;
                        cmd.Parameters.AddWithValue("@value", value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = Convert.ToInt32(reader["ID"]);
                                username = reader["Username"].ToString();
                                password = reader["Password"].ToString();
                                fullname = reader["FullName"].ToString();
                                lastname = reader["LastName"].ToString();
                                isadmin = Convert.ToBoolean(reader["IsAdmin"]);
                                department = new Department(Convert.ToInt32(reader["DepartmentID"]));
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

        public User(int id)
        {
            CheckAndUpdateField("ID", id.ToString());
        }
        public User(string username)
        {
            CheckAndUpdateField("Username", username);
        }
        //this method for update field before create new user
        public User(string Username, string Password, string FullName, string LastName, bool IsAdmin, Department Department)
        {
            username = Username;
            password = EncryptPassword(Password);
            fullname = FullName;
            lastname = LastName;
            isadmin = IsAdmin;
            department = Department;
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
                        string insert = "INSERT INTO user (ID, Username, Password, FullName, LastName, IsAdmin, DepartmentID) VALUES (NULL, @username, @password, @fullname, @lastname, @isadmin, @department)";
                        cmd.CommandText = insert;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@isadmin", isadmin);
                        cmd.Parameters.AddWithValue("@department", department.ID);
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
                        string update = "UPDATE user SET Username = @username, FullName = @fullname, LastName = @lastname, IsAdmin = @isadmin, DepartmentID = @department WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@isadmin", isadmin);
                        cmd.Parameters.AddWithValue("@department", department.ID);
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
                        string delete = "DELETE FROM user WHERE ID = @id";
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

        public bool ChangePassword(int id, string oldPassword, string newPassword)
        {
            oldPassword = EncryptPassword(oldPassword);
            if (id == this.id && oldPassword == this.password)
            {
                newPassword = EncryptPassword(newPassword);
                this.password = newPassword;
                return true;
            }
            else return false;
        }

        public bool Authenticate(string password)
        {
            password = this.EncryptPassword(password);
            if (password == this.password)
            {
                return true;
            }
            else return false;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < Math.Min(bytes.Length,16); i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
          
    }
}
