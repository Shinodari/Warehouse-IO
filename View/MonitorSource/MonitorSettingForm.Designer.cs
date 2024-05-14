namespace Warehouse_IO.View.MonitorSource
{
    partial class MonitorSettingForm
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
            this.sildeShowListbox = new System.Windows.Forms.ListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.persentOrderViewLabel = new System.Windows.Forms.Label();
            this.switchPageTimeLabel = new System.Windows.Forms.Label();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.switchingPageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.switchingPageNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sildeShowListbox
            // 
            this.sildeShowListbox.FormattingEnabled = true;
            this.sildeShowListbox.Location = new System.Drawing.Point(119, 24);
            this.sildeShowListbox.Name = "sildeShowListbox";
            this.sildeShowListbox.Size = new System.Drawing.Size(312, 342);
            this.sildeShowListbox.TabIndex = 10;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(332, 375);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(332, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // persentOrderViewLabel
            // 
            this.persentOrderViewLabel.AutoSize = true;
            this.persentOrderViewLabel.Location = new System.Drawing.Point(15, 27);
            this.persentOrderViewLabel.Name = "persentOrderViewLabel";
            this.persentOrderViewLabel.Size = new System.Drawing.Size(101, 13);
            this.persentOrderViewLabel.TabIndex = 16;
            this.persentOrderViewLabel.Text = "Present order view :";
            // 
            // switchPageTimeLabel
            // 
            this.switchPageTimeLabel.AutoSize = true;
            this.switchPageTimeLabel.Location = new System.Drawing.Point(19, 378);
            this.switchPageTimeLabel.Name = "switchPageTimeLabel";
            this.switchPageTimeLabel.Size = new System.Drawing.Size(149, 13);
            this.switchPageTimeLabel.TabIndex = 5;
            this.switchPageTimeLabel.Text = "Switch page time in secound :";
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(437, 139);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(40, 35);
            this.upButton.TabIndex = 14;
            this.upButton.Text = "▲";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(437, 180);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(40, 35);
            this.downButton.TabIndex = 15;
            this.downButton.Text = "▼";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // switchingPageNumericUpDown
            // 
            this.switchingPageNumericUpDown.Location = new System.Drawing.Point(174, 376);
            this.switchingPageNumericUpDown.Name = "switchingPageNumericUpDown";
            this.switchingPageNumericUpDown.Size = new System.Drawing.Size(149, 20);
            this.switchingPageNumericUpDown.TabIndex = 17;
            // 
            // MonitorSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 444);
            this.ControlBox = false;
            this.Controls.Add(this.switchingPageNumericUpDown);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.switchPageTimeLabel);
            this.Controls.Add(this.persentOrderViewLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sildeShowListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitor Setting";
            ((System.ComponentModel.ISupportInitialize)(this.switchingPageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sildeShowListbox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label persentOrderViewLabel;
        private System.Windows.Forms.Label switchPageTimeLabel;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.NumericUpDown switchingPageNumericUpDown;
    }
}