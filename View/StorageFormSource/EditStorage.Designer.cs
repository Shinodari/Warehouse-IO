namespace Warehouse_IO.View.StorageFormSource
{
    partial class EditStorage
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
            this.oldStoNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editDepExitButton = new System.Windows.Forms.Button();
            this.addStoTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldStoNameLabel
            // 
            this.oldStoNameLabel.AutoSize = true;
            this.oldStoNameLabel.Location = new System.Drawing.Point(91, 28);
            this.oldStoNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.oldStoNameLabel.Name = "oldStoNameLabel";
            this.oldStoNameLabel.Size = new System.Drawing.Size(58, 13);
            this.oldStoNameLabel.TabIndex = 13;
            this.oldStoNameLabel.Text = "Old name :";
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
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Storage Location Name";
            // 
            // editDepExitButton
            // 
            this.editDepExitButton.Location = new System.Drawing.Point(94, 97);
            this.editDepExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.editDepExitButton.Name = "editDepExitButton";
            this.editDepExitButton.Size = new System.Drawing.Size(62, 50);
            this.editDepExitButton.TabIndex = 10;
            this.editDepExitButton.Text = "CANCEL";
            this.editDepExitButton.UseVisualStyleBackColor = true;
            this.editDepExitButton.Click += new System.EventHandler(this.editStoExitButton_Click);
            // 
            // addStoTextBox
            // 
            this.addStoTextBox.Location = new System.Drawing.Point(14, 55);
            this.addStoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addStoTextBox.Name = "addStoTextBox";
            this.addStoTextBox.Size = new System.Drawing.Size(143, 20);
            this.addStoTextBox.TabIndex = 9;
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
            this.button1.Click += new System.EventHandler(this.editStoOKButton_Click);
            // 
            // EditStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oldStoNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editDepExitButton);
            this.Controls.Add(this.addStoTextBox);
            this.Controls.Add(this.button1);
            this.Name = "EditStorage";
            this.Size = new System.Drawing.Size(170, 160);
            this.Load += new System.EventHandler(this.EditSto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldStoNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editDepExitButton;
        private System.Windows.Forms.TextBox addStoTextBox;
        private System.Windows.Forms.Button button1;
    }
}
