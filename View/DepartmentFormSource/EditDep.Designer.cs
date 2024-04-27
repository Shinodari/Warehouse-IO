namespace Warehouse_IO
{
    partial class EditDep
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
            this.button1 = new System.Windows.Forms.Button();
            this.addDepTextBox = new System.Windows.Forms.TextBox();
            this.editDepExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oldNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.editDepOKButton_Click);
            // 
            // addDepTextBox
            // 
            this.addDepTextBox.Location = new System.Drawing.Point(14, 55);
            this.addDepTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addDepTextBox.Name = "addDepTextBox";
            this.addDepTextBox.Size = new System.Drawing.Size(143, 20);
            this.addDepTextBox.TabIndex = 3;
            // 
            // editDepExitButton
            // 
            this.editDepExitButton.Location = new System.Drawing.Point(94, 97);
            this.editDepExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.editDepExitButton.Name = "editDepExitButton";
            this.editDepExitButton.Size = new System.Drawing.Size(62, 50);
            this.editDepExitButton.TabIndex = 4;
            this.editDepExitButton.Text = "CANCEL";
            this.editDepExitButton.UseVisualStyleBackColor = true;
            this.editDepExitButton.Click += new System.EventHandler(this.editDepExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Department Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Old name :";
            // 
            // oldNameLabel
            // 
            this.oldNameLabel.AutoSize = true;
            this.oldNameLabel.Location = new System.Drawing.Point(91, 28);
            this.oldNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.oldNameLabel.Name = "oldNameLabel";
            this.oldNameLabel.Size = new System.Drawing.Size(58, 13);
            this.oldNameLabel.TabIndex = 7;
            this.oldNameLabel.Text = "Old name :";
            // 
            // EditDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oldNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editDepExitButton);
            this.Controls.Add(this.addDepTextBox);
            this.Controls.Add(this.button1);
            this.Name = "EditDep";
            this.Size = new System.Drawing.Size(170, 160);
            this.Load += new System.EventHandler(this.EditDep_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox addDepTextBox;
        private System.Windows.Forms.Button editDepExitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label oldNameLabel;
    }
}
