﻿using System;
using System.Collections.Generic;
using Warehouse_IO.Authentication;
using System.Windows.Forms;
using Warehouse_IO.WHIO.Model;

namespace Warehouse_IO.View.CreateUseForm
{
    public partial class CreateUserForm : Form
    {
        User user;
        Department department;

        List<Department> departmentlist;

        private List<int> departmentID = new List<int>();

        MainForm main;
        public event EventHandler returnMain;
        public CreateUserForm()
        {
            InitializeComponent();
            departmentlist = new List<Department>();
            main = new MainForm();
            updatecomponent();
        }

        private void updatecomponent()
        {
            departmentlist = Department.GetDepartmentList();
            departmentComboBox.Items.Clear();
            foreach(Department dep in departmentlist)
            {
                departmentComboBox.Items.Add(dep.Name);
                departmentID.Add(dep.ID);
            }
        }

        private void CreateUser()
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                MessageBox.Show(this, "Username must be put");
                return;
            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show(this, "Passsword must be put");
                return;
            }
            if (string.IsNullOrEmpty(fullnameTextBox.Text))
            {
                MessageBox.Show(this, "Fullname must be put");
                return;
            }
            if (string.IsNullOrEmpty(lastnameTextBox.Text))
            {
                MessageBox.Show(this, "Lastname must be put");
                return;
            }
            int selectedDepartmentIndex = departmentComboBox.SelectedIndex;
            if(selectedDepartmentIndex >= 0 && selectedDepartmentIndex < departmentID.Count)
            {
                int selectedDepID = departmentID[selectedDepartmentIndex];
                department = new Department(selectedDepID);
            }
            else
            {
                MessageBox.Show(this, "Please select Department");
                return;
            }
            user = new Authentication.User(userNameTextBox.Text, passwordTextBox.Text, fullnameTextBox.Text, lastnameTextBox.Text, isAdminCheckBox.Checked, department);
            if (user.Create())
            {
                MessageBox.Show(this, "Create Completed");
            }
            else MessageBox.Show(this, "Create Fail");
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            CreateUser();
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}