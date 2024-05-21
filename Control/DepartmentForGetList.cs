
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse_IO.Control
{
    public class DepartmentForGetList
    {

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Storgae { get; set; }

        static string connstr = Settings.Default.CONNECTION_STRING;

        public DepartmentForGetList(int id, string name,string storgae)
        {
            this.DepartmentID = id;
            this.DepartmentName = name;
            this.Storgae = storgae;
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
                            departmentList.Add(new DepartmentForGetList(id, name, dephaves));
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
