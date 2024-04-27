namespace Warehouse_IO.View.TruckFormSource
{
    partial class EditTruck
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSupExitButton = new System.Windows.Forms.Button();
            this.addTruckTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AddTruckDescTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(21, 33);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 17;
            this.nameLabel.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Edit : Truck Name and Description";
            // 
            // editSupExitButton
            // 
            this.editSupExitButton.Location = new System.Drawing.Point(182, 102);
            this.editSupExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.editSupExitButton.Name = "editSupExitButton";
            this.editSupExitButton.Size = new System.Drawing.Size(62, 50);
            this.editSupExitButton.TabIndex = 15;
            this.editSupExitButton.Text = "CANCEL";
            this.editSupExitButton.UseVisualStyleBackColor = true;
            this.editSupExitButton.Click += new System.EventHandler(this.editTruckExitButton_Click);
            // 
            // addTruckTextBox
            // 
            this.addTruckTextBox.Location = new System.Drawing.Point(102, 29);
            this.addTruckTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addTruckTextBox.Name = "addTruckTextBox";
            this.addTruckTextBox.Size = new System.Drawing.Size(143, 20);
            this.addTruckTextBox.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditTruckOKButton_Click);
            // 
            // AddTruckDescTextBox
            // 
            this.AddTruckDescTextBox.Location = new System.Drawing.Point(102, 70);
            this.AddTruckDescTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddTruckDescTextBox.Name = "AddTruckDescTextBox";
            this.AddTruckDescTextBox.Size = new System.Drawing.Size(143, 20);
            this.AddTruckDescTextBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description :";
            // 
            // EditTruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddTruckDescTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSupExitButton);
            this.Controls.Add(this.addTruckTextBox);
            this.Controls.Add(this.button1);
            this.Name = "EditTruck";
            this.Size = new System.Drawing.Size(346, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editSupExitButton;
        private System.Windows.Forms.TextBox addTruckTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox AddTruckDescTextBox;
        private System.Windows.Forms.Label label2;
    }
}
