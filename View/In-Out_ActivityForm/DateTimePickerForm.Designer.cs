namespace Warehouse_IO.View.In_Out_ActivityForm
{
    partial class DateTimePickerForm
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
            this.firstFormDatePicker = new System.Windows.Forms.DateTimePicker();
            this.firstToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.secondFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.secondToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.firstTimelineLabel = new System.Windows.Forms.Label();
            this.from1TimelineLabel = new System.Windows.Forms.Label();
            this.to1TimelineLabel = new System.Windows.Forms.Label();
            this.secoundTimelineLabel = new System.Windows.Forms.Label();
            this.from2TimelineLabel = new System.Windows.Forms.Label();
            this.to2TimelineLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // firstFormDatePicker
            // 
            this.firstFormDatePicker.Location = new System.Drawing.Point(146, 52);
            this.firstFormDatePicker.Name = "firstFormDatePicker";
            this.firstFormDatePicker.Size = new System.Drawing.Size(200, 20);
            this.firstFormDatePicker.TabIndex = 10;
            // 
            // firstToDatePicker
            // 
            this.firstToDatePicker.Location = new System.Drawing.Point(146, 98);
            this.firstToDatePicker.Name = "firstToDatePicker";
            this.firstToDatePicker.Size = new System.Drawing.Size(200, 20);
            this.firstToDatePicker.TabIndex = 11;
            // 
            // secondFromDatePicker
            // 
            this.secondFromDatePicker.Location = new System.Drawing.Point(146, 197);
            this.secondFromDatePicker.Name = "secondFromDatePicker";
            this.secondFromDatePicker.Size = new System.Drawing.Size(200, 20);
            this.secondFromDatePicker.TabIndex = 12;
            // 
            // secondToDatePicker
            // 
            this.secondToDatePicker.Location = new System.Drawing.Point(146, 245);
            this.secondToDatePicker.Name = "secondToDatePicker";
            this.secondToDatePicker.Size = new System.Drawing.Size(200, 20);
            this.secondToDatePicker.TabIndex = 13;
            // 
            // firstTimelineLabel
            // 
            this.firstTimelineLabel.AutoSize = true;
            this.firstTimelineLabel.Location = new System.Drawing.Point(210, 21);
            this.firstTimelineLabel.Name = "firstTimelineLabel";
            this.firstTimelineLabel.Size = new System.Drawing.Size(68, 13);
            this.firstTimelineLabel.TabIndex = 100;
            this.firstTimelineLabel.Text = "First Timeline";
            // 
            // from1TimelineLabel
            // 
            this.from1TimelineLabel.AutoSize = true;
            this.from1TimelineLabel.Location = new System.Drawing.Point(68, 58);
            this.from1TimelineLabel.Name = "from1TimelineLabel";
            this.from1TimelineLabel.Size = new System.Drawing.Size(36, 13);
            this.from1TimelineLabel.TabIndex = 101;
            this.from1TimelineLabel.Text = "From :";
            // 
            // to1TimelineLabel
            // 
            this.to1TimelineLabel.AutoSize = true;
            this.to1TimelineLabel.Location = new System.Drawing.Point(68, 105);
            this.to1TimelineLabel.Name = "to1TimelineLabel";
            this.to1TimelineLabel.Size = new System.Drawing.Size(26, 13);
            this.to1TimelineLabel.TabIndex = 102;
            this.to1TimelineLabel.Text = "To :";
            // 
            // secoundTimelineLabel
            // 
            this.secoundTimelineLabel.AutoSize = true;
            this.secoundTimelineLabel.Location = new System.Drawing.Point(202, 168);
            this.secoundTimelineLabel.Name = "secoundTimelineLabel";
            this.secoundTimelineLabel.Size = new System.Drawing.Size(86, 13);
            this.secoundTimelineLabel.TabIndex = 105;
            this.secoundTimelineLabel.Text = "Second Timeline";
            // 
            // from2TimelineLabel
            // 
            this.from2TimelineLabel.AutoSize = true;
            this.from2TimelineLabel.Location = new System.Drawing.Point(68, 203);
            this.from2TimelineLabel.Name = "from2TimelineLabel";
            this.from2TimelineLabel.Size = new System.Drawing.Size(36, 13);
            this.from2TimelineLabel.TabIndex = 103;
            this.from2TimelineLabel.Text = "From :";
            // 
            // to2TimelineLabel
            // 
            this.to2TimelineLabel.AutoSize = true;
            this.to2TimelineLabel.Location = new System.Drawing.Point(68, 251);
            this.to2TimelineLabel.Name = "to2TimelineLabel";
            this.to2TimelineLabel.Size = new System.Drawing.Size(26, 13);
            this.to2TimelineLabel.TabIndex = 104;
            this.to2TimelineLabel.Text = "To :";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(146, 310);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 50);
            this.generateButton.TabIndex = 106;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(225, 310);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(121, 21);
            this.customerComboBox.TabIndex = 107;
            // 
            // DateTimePickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 410);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.to2TimelineLabel);
            this.Controls.Add(this.from2TimelineLabel);
            this.Controls.Add(this.secoundTimelineLabel);
            this.Controls.Add(this.to1TimelineLabel);
            this.Controls.Add(this.from1TimelineLabel);
            this.Controls.Add(this.firstTimelineLabel);
            this.Controls.Add(this.secondToDatePicker);
            this.Controls.Add(this.secondFromDatePicker);
            this.Controls.Add(this.firstToDatePicker);
            this.Controls.Add(this.firstFormDatePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateTimePickerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker firstFormDatePicker;
        private System.Windows.Forms.DateTimePicker firstToDatePicker;
        private System.Windows.Forms.DateTimePicker secondFromDatePicker;
        private System.Windows.Forms.DateTimePicker secondToDatePicker;
        private System.Windows.Forms.Label firstTimelineLabel;
        private System.Windows.Forms.Label from1TimelineLabel;
        private System.Windows.Forms.Label to1TimelineLabel;
        private System.Windows.Forms.Label secoundTimelineLabel;
        private System.Windows.Forms.Label from2TimelineLabel;
        private System.Windows.Forms.Label to2TimelineLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ComboBox customerComboBox;
    }
}