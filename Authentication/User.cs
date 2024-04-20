using System;
using System.Text;
using Warehouse_IO.WHIO.Model;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Warehouse_IO.Authentication
{
    class User
    {
        int id;
        public int ID { get; }
        string username;
        public string Username { get; set; }
        string password;
        private string Password;
        string fullname;
        public string FullName { get; set; }
        string lastname;
        public string LastName { get; set; }
        bool isadmin;
        public bool IsAdmin { get; set; }
        Department department;
        public Department Department { get; set; }

        string connstr = Settings.Default.CONNECTION_STRING;

        //this method for checking parameter to retrive database
        private void CheckAndUpdateField(string columnName, string value)
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
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
                    conn.Close();
                }
            }
            catch (MySqlException e) { }
        }

        public User(int id)
        {
            this.CheckAndUpdateField("ID", id.ToString());
        }
        public User(string username)
        {
            this.CheckAndUpdateField("Username", username);
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
        
        public int GetID() { return ID; }
        public string GetUserName() { return Username; }
        public string GetFullName() { return FullName; }
        public string GetLastName() { return LastName; }
        public bool GetIsAdmin() { return IsAdmin; }
        public Department GetDepartment() { return Department; }

        public void SetUserName(string username)
        {
            this.username = username;
        }
        public void SetFullName(string fullname)
        {
            this.fullname = fullname;
        }
        public void SetLastName(string lastname)
        {
            this.lastname = lastname;
        }
        public void SetIsAdmin(bool isadmin)
        {
            this.isadmin = isadmin;
        }
        public void SetDepartment(Department department)
        {
            this.department = department;
        }

        public bool Create()
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
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
                        cmd.Parameters.AddWithValue("@department", department.GetID());
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
                        string update = "UPDATE user SET Username = @username, FullName = @fullname, LastName = @lastname, IsAdmin = @isadmin, DepartmentID = @department WHERE ID = @id ";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@lastname", lastname);
                        cmd.Parameters.AddWithValue("@isadmin", isadmin);
                        cmd.Parameters.AddWithValue("@department", department.GetID());
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
        public bool Remove()
        {
            try
            {
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string delete = "DELETE FROM user WHERE ID = @id";
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

        public bool ChangePassword(int id, string oldPassword, string newPassword)
        {
            oldPassword = EncryptPassword(oldPassword);
            if (id == ID && oldPassword == password)
            {
                newPassword = EncryptPassword(newPassword);
                this.password = newPassword;
                return true;
            }
            else return false;
        }

        public bool Authenticate(string password1)
        {
            password1 = this.EncryptPassword(password1);
            if (password1 == password)
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
