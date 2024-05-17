namespace Warehouse_IO.View
{
    partial class Edit_ConnectionStringForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipServerTextbox = new System.Windows.Forms.TextBox();
            this.userDatabaseTextbox = new System.Windows.Forms.TextBox();
            this.passwordDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.databaseUserLabel = new System.Windows.Forms.Label();
            this.passwordDBLabel = new System.Windows.Forms.Label();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipServerTextbox
            // 
            this.ipServerTextbox.Location = new System.Drawing.Point(124, 29);
            this.ipServerTextbox.Name = "ipServerTextbox";
            this.ipServerTextbox.Size = new System.Drawing.Size(239, 20);
            this.ipServerTextbox.TabIndex = 10;
            // 
            // userDatabaseTextbox
            // 
            this.userDatabaseTextbox.Location = new System.Drawing.Point(124, 73);
            this.userDatabaseTextbox.Name = "userDatabaseTextbox";
            this.userDatabaseTextbox.Size = new System.Drawing.Size(239, 20);
            this.userDatabaseTextbox.TabIndex = 11;
            // 
            // passwordDatabaseTextBox
            // 
            this.passwordDatabaseTextBox.Location = new System.Drawing.Point(124, 119);
            this.passwordDatabaseTextBox.Name = "passwordDatabaseTextBox";
            this.passwordDatabaseTextBox.Size = new System.Drawing.Size(239, 20);
            this.passwordDatabaseTextBox.TabIndex = 12;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(48, 29);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(57, 13);
            this.ipLabel.TabIndex = 100;
            this.ipLabel.Text = "Server IP :";
            // 
            // databaseUserLabel
            // 
            this.databaseUserLabel.AutoSize = true;
            this.databaseUserLabel.Location = new System.Drawing.Point(34, 76);
            this.databaseUserLabel.Name = "databaseUserLabel";
            this.databaseUserLabel.Size = new System.Drawing.Size(84, 13);
            this.databaseUserLabel.TabIndex = 101;
            this.databaseUserLabel.Text = "Database User :";
            // 
            // passwordDBLabel
            // 
            this.passwordDBLabel.AutoSize = true;
            this.passwordDBLabel.Location = new System.Drawing.Point(13, 122);
            this.passwordDBLabel.Name = "passwordDBLabel";
            this.passwordDBLabel.Size = new System.Drawing.Size(108, 13);
            this.passwordDBLabel.TabIndex = 102;
            this.passwordDBLabel.Text = "Database Password :";
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(124, 165);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(239, 20);
            this.databaseNameTextBox.TabIndex = 13;
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Location = new System.Drawing.Point(31, 168);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(90, 13);
            this.databaseNameLabel.TabIndex = 103;
            this.databaseNameLabel.Text = "Database Name :";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(124, 237);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 104;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(288, 237);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 105;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Edit_ConnectionStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 375);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.databaseNameLabel);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.passwordDBLabel);
            this.Controls.Add(this.databaseUserLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.passwordDatabaseTextBox);
            this.Controls.Add(this.userDatabaseTextbox);
            this.Controls.Add(this.ipServerTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_ConnectionStringForm";
            this.Text = "Edit Connection String";
            this.Load += new System.EventHandler(this.Edit_ConnectionStringForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipServerTextbox;
        private System.Windows.Forms.TextBox userDatabaseTextbox;
        private System.Windows.Forms.TextBox passwordDatabaseTextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label databaseUserLabel;
        private System.Windows.Forms.Label passwordDBLabel;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button exitButton;
    }
}