namespace Warehouse_IO.View.SupplierFormSource
{
    partial class EditSup
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
            this.oldNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editSupExitButton = new System.Windows.Forms.Button();
            this.addSupTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldNameLabel
            // 
            this.oldNameLabel.AutoSize = true;
            this.oldNameLabel.Location = new System.Drawing.Point(91, 28);
            this.oldNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.oldNameLabel.Name = "oldNameLabel";
            this.oldNameLabel.Size = new System.Drawing.Size(58, 13);
            this.oldNameLabel.TabIndex = 13;
            this.oldNameLabel.Text = "Old name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Old name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Supplier Name";
            // 
            // editSupExitButton
            // 
            this.editSupExitButton.Location = new System.Drawing.Point(94, 97);
            this.editSupExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.editSupExitButton.Name = "editSupExitButton";
            this.editSupExitButton.Size = new System.Drawing.Size(62, 50);
            this.editSupExitButton.TabIndex = 10;
            this.editSupExitButton.Text = "CANCEL";
            this.editSupExitButton.UseVisualStyleBackColor = true;
            this.editSupExitButton.Click += new System.EventHandler(this.editSupExitButton_Click);
            // 
            // addSupTextBox
            // 
            this.addSupTextBox.Location = new System.Drawing.Point(14, 55);
            this.addSupTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addSupTextBox.Name = "addSupTextBox";
            this.addSupTextBox.Size = new System.Drawing.Size(143, 20);
            this.addSupTextBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditSupOKButton_Click);
            // 
            // EditSup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oldNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editSupExitButton);
            this.Controls.Add(this.addSupTextBox);
            this.Controls.Add(this.button1);
            this.Name = "EditSup";
            this.Size = new System.Drawing.Size(170, 160);
            this.Load += new System.EventHandler(this.EditSup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editSupExitButton;
        private System.Windows.Forms.TextBox addSupTextBox;
        private System.Windows.Forms.Button button1;
    }
}
