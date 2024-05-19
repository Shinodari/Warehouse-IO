namespace Warehouse_IO.Chart
{
    partial class ChartDisplayForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.inboundChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.outboundChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inboundTruckChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.outboundTruckChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.firstTimelineLabel = new System.Windows.Forms.Label();
            this.secondTimelineLabel = new System.Windows.Forms.Label();
            this.fFDateLabel = new System.Windows.Forms.Label();
            this.sFDateLabel = new System.Windows.Forms.Label();
            this.fToDateLabel = new System.Windows.Forms.Label();
            this.sToDateLabel = new System.Windows.Forms.Label();
            this.ftlToLabel = new System.Windows.Forms.Label();
            this.stlDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inboundChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inboundTruckChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundTruckChart)).BeginInit();
            this.SuspendLayout();
            // 
            // inboundChart
            // 
            chartArea5.Name = "ChartArea1";
            this.inboundChart.ChartAreas.Add(chartArea5);
            legend5.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend5.Name = "Legend1";
            this.inboundChart.Legends.Add(legend5);
            this.inboundChart.Location = new System.Drawing.Point(4, 4);
            this.inboundChart.Name = "inboundChart";
            this.inboundChart.Size = new System.Drawing.Size(500, 300);
            this.inboundChart.TabIndex = 0;
            this.inboundChart.Text = "Inbound";
            // 
            // outboundChart
            // 
            chartArea6.Name = "ChartArea1";
            this.outboundChart.ChartAreas.Add(chartArea6);
            legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend6.Name = "Legend1";
            this.outboundChart.Legends.Add(legend6);
            this.outboundChart.Location = new System.Drawing.Point(507, 4);
            this.outboundChart.Name = "outboundChart";
            this.outboundChart.Size = new System.Drawing.Size(500, 300);
            this.outboundChart.TabIndex = 1;
            this.outboundChart.Text = "Outbound";
            // 
            // inboundTruckChart
            // 
            chartArea7.Name = "ChartArea1";
            this.inboundTruckChart.ChartAreas.Add(chartArea7);
            legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend7.Name = "Legend1";
            this.inboundTruckChart.Legends.Add(legend7);
            this.inboundTruckChart.Location = new System.Drawing.Point(4, 417);
            this.inboundTruckChart.Name = "inboundTruckChart";
            this.inboundTruckChart.Size = new System.Drawing.Size(500, 300);
            this.inboundTruckChart.TabIndex = 2;
            this.inboundTruckChart.Text = "InboundTruck";
            // 
            // outboundTruckChart
            // 
            chartArea8.Name = "ChartArea1";
            this.outboundTruckChart.ChartAreas.Add(chartArea8);
            legend8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend8.Name = "Legend1";
            this.outboundTruckChart.Legends.Add(legend8);
            this.outboundTruckChart.Location = new System.Drawing.Point(507, 417);
            this.outboundTruckChart.Name = "outboundTruckChart";
            this.outboundTruckChart.Size = new System.Drawing.Size(500, 300);
            this.outboundTruckChart.TabIndex = 3;
            this.outboundTruckChart.Text = "OutboundTruck";
            // 
            // firstTimelineLabel
            // 
            this.firstTimelineLabel.AutoSize = true;
            this.firstTimelineLabel.Location = new System.Drawing.Point(196, 330);
            this.firstTimelineLabel.Name = "firstTimelineLabel";
            this.firstTimelineLabel.Size = new System.Drawing.Size(124, 13);
            this.firstTimelineLabel.TabIndex = 4;
            this.firstTimelineLabel.Text = "First Timeline From date :";
            // 
            // secondTimelineLabel
            // 
            this.secondTimelineLabel.AutoSize = true;
            this.secondTimelineLabel.Location = new System.Drawing.Point(178, 370);
            this.secondTimelineLabel.Name = "secondTimelineLabel";
            this.secondTimelineLabel.Size = new System.Drawing.Size(142, 13);
            this.secondTimelineLabel.TabIndex = 5;
            this.secondTimelineLabel.Text = "Second Timeline From date :";
            // 
            // fFDateLabel
            // 
            this.fFDateLabel.AutoSize = true;
            this.fFDateLabel.Location = new System.Drawing.Point(384, 330);
            this.fFDateLabel.Name = "fFDateLabel";
            this.fFDateLabel.Size = new System.Drawing.Size(35, 13);
            this.fFDateLabel.TabIndex = 6;
            this.fFDateLabel.Text = "label1";
            // 
            // sFDateLabel
            // 
            this.sFDateLabel.AutoSize = true;
            this.sFDateLabel.Location = new System.Drawing.Point(384, 370);
            this.sFDateLabel.Name = "sFDateLabel";
            this.sFDateLabel.Size = new System.Drawing.Size(35, 13);
            this.sFDateLabel.TabIndex = 7;
            this.sFDateLabel.Text = "label2";
            // 
            // fToDateLabel
            // 
            this.fToDateLabel.AutoSize = true;
            this.fToDateLabel.Location = new System.Drawing.Point(521, 330);
            this.fToDateLabel.Name = "fToDateLabel";
            this.fToDateLabel.Size = new System.Drawing.Size(50, 13);
            this.fToDateLabel.TabIndex = 8;
            this.fToDateLabel.Text = "To date :";
            // 
            // sToDateLabel
            // 
            this.sToDateLabel.AutoSize = true;
            this.sToDateLabel.Location = new System.Drawing.Point(521, 370);
            this.sToDateLabel.Name = "sToDateLabel";
            this.sToDateLabel.Size = new System.Drawing.Size(50, 13);
            this.sToDateLabel.TabIndex = 9;
            this.sToDateLabel.Text = "To date :";
            // 
            // ftlToLabel
            // 
            this.ftlToLabel.AutoSize = true;
            this.ftlToLabel.Location = new System.Drawing.Point(657, 330);
            this.ftlToLabel.Name = "ftlToLabel";
            this.ftlToLabel.Size = new System.Drawing.Size(35, 13);
            this.ftlToLabel.TabIndex = 10;
            this.ftlToLabel.Text = "label2";
            // 
            // stlDateLabel
            // 
            this.stlDateLabel.AutoSize = true;
            this.stlDateLabel.Location = new System.Drawing.Point(657, 370);
            this.stlDateLabel.Name = "stlDateLabel";
            this.stlDateLabel.Size = new System.Drawing.Size(35, 13);
            this.stlDateLabel.TabIndex = 11;
            this.stlDateLabel.Text = "label2";
            // 
            // ChartDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.stlDateLabel);
            this.Controls.Add(this.ftlToLabel);
            this.Controls.Add(this.sToDateLabel);
            this.Controls.Add(this.fToDateLabel);
            this.Controls.Add(this.sFDateLabel);
            this.Controls.Add(this.fFDateLabel);
            this.Controls.Add(this.secondTimelineLabel);
            this.Controls.Add(this.firstTimelineLabel);
            this.Controls.Add(this.outboundTruckChart);
            this.Controls.Add(this.inboundTruckChart);
            this.Controls.Add(this.outboundChart);
            this.Controls.Add(this.inboundChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operation Report";
            ((System.ComponentModel.ISupportInitialize)(this.inboundChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inboundTruckChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outboundTruckChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart inboundChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart outboundChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart inboundTruckChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart outboundTruckChart;
        private System.Windows.Forms.Label firstTimelineLabel;
        private System.Windows.Forms.Label secondTimelineLabel;
        private System.Windows.Forms.Label fFDateLabel;
        private System.Windows.Forms.Label sFDateLabel;
        private System.Windows.Forms.Label fToDateLabel;
        private System.Windows.Forms.Label sToDateLabel;
        private System.Windows.Forms.Label ftlToLabel;
        private System.Windows.Forms.Label stlDateLabel;
    }
}