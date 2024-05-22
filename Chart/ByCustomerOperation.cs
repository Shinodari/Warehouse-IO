using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Warehouse_IO.Common;

namespace Warehouse_IO.Chart
{
    public partial class ByCustomerOperation : Form
    {
        DateTime from1Timeline = Global.fromDate1Timeline;
        DateTime to1Timeline = Global.toDate1Timeline;

        DateTime from2Timeline = Global.fromDate2Timeline;
        DateTime to2Timeline = Global.toDate2Timeline;

        List<InboundVolumeByCustomer> inboundListByCustomer;
        List<OutboundVolumeByCustomer> outboundListByCustomer;

        List<InboundTruckByCustomer> inboundTruckListByCustomer;
        List<OutboundTruckByCustomer> outboundTruckListByCustomer;

        public ByCustomerOperation()
        {
            InitializeComponent();

            fFDateLabel.Text = from1Timeline.ToString("MMM, dd yyyy");
            ftlToLabel.Text = to1Timeline.ToString("MMM, dd yyyy");
            sFDateLabel.Text = from2Timeline.ToString("MMM, dd yyyy");
            stlDateLabel.Text = to2Timeline.ToString("MMM, dd yyyy");

            // Create a new series for Inbound M3
            Series inbSeries1 = new Series("Inbound History")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.DarkBlue
            };
            Series inbSeries2 = new Series("Inbound Present")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red
            };
            // Create a new series for Outbound M3
            Series oubSeries1 = new Series("Outbound History")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.DarkBlue
            };
            Series oubSeries2 = new Series("Outbound Present")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Red
            };
            // Create a new series for Inbound Truck
            Series inbTsereies1 = new Series("20F")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.DarkBlue
            };
            Series inbTsereies2 = new Series("40F")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Red
            };
            // Create a new series for OutBound Truck
            Series oubTsereies1 = new Series("4W")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.DarkBlue
            };
            Series oubTsereies2 = new Series("6W")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Red
            };
            Series oubTsereies3 = new Series("10W")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Lime
            };
            Series oubTsereies4 = new Series("20F")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Violet
            };
            Series oubTsereies5 = new Series("40F")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.Tan
            };

            //Chart Title
            inboundChart.Titles.Add("Inbound M3 cumulative");
            outboundChart.Titles.Add("Outbound M3 cumulative");
            inboundTruckChart.Titles.Add("Container Un-Stuffing Comparision");
            outboundTruckChart.Titles.Add("Container & Truck Stuffing Comparision");

            // Add the series to the chart
            inboundChart.Series.Add(inbSeries1);
            inboundChart.Series.Add(inbSeries2);

            outboundChart.Series.Add(oubSeries1);
            outboundChart.Series.Add(oubSeries2);

            inboundTruckChart.Series.Add(inbTsereies1);
            inboundTruckChart.Series.Add(inbTsereies2);

            outboundTruckChart.Series.Add(oubTsereies1);
            outboundTruckChart.Series.Add(oubTsereies2);
            outboundTruckChart.Series.Add(oubTsereies3);
            outboundTruckChart.Series.Add(oubTsereies4);
            outboundTruckChart.Series.Add(oubTsereies5);

            inboundListByCustomer = InboundVolumeByCustomer.GetInboundListByCustomer(Global.tempPkeyName);
            outboundListByCustomer = OutboundVolumeByCustomer.GetOutboundListByCustomer(Global.tempPkeyName);

            inboundTruckListByCustomer = InboundTruckByCustomer.GetTruckInboundListByCustomer(Global.tempPkeyName);
            outboundTruckListByCustomer = OutboundTruckByCustomer.GetTruckOutboundListByCustomer(Global.tempPkeyName);

            UpdateInboundChartByCustomer();
            UpdateOutboundChartByCustomer();

            UpdateTruckInboundChartByCustomer();
            UpdateTruckOutboundChartByCustomer();
        }

        private void UpdateInboundChartByCustomer()
        {
            inboundChart.Series[0].Points.Clear();
            inboundChart.Series[1].Points.Clear();

            // Calculate the number of days in each timeline
            int daysInTimeline1 = (to1Timeline - from1Timeline).Days + 1;
            int daysInTimeline2 = (to2Timeline - from2Timeline).Days + 1;

            double cumulativeM3Timeline1 = 0;
            double cumulativeM3Timeline2 = 0;

            // Use a loop to iterate through the maximum number of days
            for (int day = 1; day <= Math.Max(daysInTimeline1, daysInTimeline2); day++)
            {
                DateTime currentDateTimeline1 = from1Timeline.AddDays(day - 1);
                DateTime currentDateTimeline2 = from2Timeline.AddDays(day - 1);

                foreach (InboundVolumeByCustomer inb in inboundListByCustomer)
                {
                    if (inb.Date.Date == currentDateTimeline1.Date)
                    {
                        cumulativeM3Timeline1 += inb.M3;
                    }
                    if (inb.Date.Date == currentDateTimeline2.Date)
                    {
                        cumulativeM3Timeline2 += inb.M3;
                    }
                }

                // Add data points with day number as X-value and cumulative M3 as Y-value
                if (day <= daysInTimeline1)
                {
                    inboundChart.Series[0].Points.AddXY(day, cumulativeM3Timeline1);
                }
                if (day <= daysInTimeline2)
                {
                    inboundChart.Series[1].Points.AddXY(day, cumulativeM3Timeline2);
                }
            }
        }

        private void UpdateOutboundChartByCustomer()
        {
            outboundChart.Series[0].Points.Clear();
            outboundChart.Series[1].Points.Clear();

            // Calculate the number of days in each timeline
            int daysInTimeline1 = (to1Timeline - from1Timeline).Days + 1;
            int daysInTimeline2 = (to2Timeline - from2Timeline).Days + 1;

            double cumulativeM3Timeline1 = 0;
            double cumulativeM3Timeline2 = 0;

            // Use a loop to iterate through the maximum number of days
            for (int day = 1; day <= Math.Max(daysInTimeline1, daysInTimeline2); day++)
            {
                DateTime currentDateTimeline1 = from1Timeline.AddDays(day - 1);
                DateTime currentDateTimeline2 = from2Timeline.AddDays(day - 1);

                foreach (OutboundVolumeByCustomer oub in outboundListByCustomer)
                {
                    if (oub.Date.Date == currentDateTimeline1.Date)
                    {
                        cumulativeM3Timeline1 += oub.M3;
                    }
                    if (oub.Date.Date == currentDateTimeline2.Date)
                    {
                        cumulativeM3Timeline2 += oub.M3;
                    }
                }

                // Add data points with day number as X-value and cumulative M3 as Y-value
                if (day <= daysInTimeline1)
                {
                    outboundChart.Series[0].Points.AddXY(day, cumulativeM3Timeline1);
                }
                if (day <= daysInTimeline2)
                {
                    outboundChart.Series[1].Points.AddXY(day, cumulativeM3Timeline2);
                }
            }
        }

        private void UpdateTruckInboundChartByCustomer()
        {
            for (int i = 0; i < inboundTruckChart.Series.Count; i++)
            {
                inboundTruckChart.Series[i].Points.Clear();
            }
            int counter20FLastTime = 0;
            int counter40FLastTime = 0;
            int counter20FCurrentTime = 0;
            int counter40FCurrentTime = 0;

            foreach (InboundTruckByCustomer inbT in inboundTruckListByCustomer)
            {
                if (inbT.Date.Date >= from2Timeline.Date && inbT.Date.Date <= to2Timeline.Date)
                {
                    if (inbT.TypeName == "20F")
                    {
                        counter20FCurrentTime += inbT.Quantity;
                    }
                    else counter40FCurrentTime += inbT.Quantity;
                }
                else if (inbT.Date.Date >= from1Timeline.Date && inbT.Date.Date <= to1Timeline.Date)
                {
                    if (inbT.TypeName == "20F")
                    {
                        counter20FLastTime += inbT.Quantity;
                    }
                    else counter40FLastTime += inbT.Quantity;
                }
            }
            inboundTruckChart.Series[0].Points.Add(counter20FLastTime);
            inboundTruckChart.Series[0].Points.Add(counter20FCurrentTime);

            inboundTruckChart.Series[1].Points.Add(counter40FLastTime);
            inboundTruckChart.Series[1].Points.Add(counter40FCurrentTime);

            inboundTruckChart.Series[0].Points[0].Label = counter20FLastTime.ToString();
            inboundTruckChart.Series[0].Points[1].Label = counter20FCurrentTime.ToString();

            inboundTruckChart.Series[1].Points[0].Label = counter40FLastTime.ToString();
            inboundTruckChart.Series[1].Points[1].Label = counter40FCurrentTime.ToString();
        }

        private void UpdateTruckOutboundChartByCustomer()
        {
            for (int i = 0; i < outboundTruckChart.Series.Count; i++)
            {
                outboundTruckChart.Series[i].Points.Clear();
            }

            int counter4WLastTime = 0;
            int counter6WLastTime = 0;
            int counter10WLastTime = 0;
            int counter20FLastTime = 0;
            int counter40FLastTime = 0;

            int counter4WCurrentTime = 0;
            int counter6WCurrentTime = 0;
            int counter10WCurrentTime = 0;
            int counter20FCurrentTime = 0;
            int counter40FCurrentTime = 0;

            foreach (OutboundTruckByCustomer oubT in outboundTruckListByCustomer)
            {
                if (oubT.Date.Date >= from2Timeline.Date && oubT.Date.Date <= to2Timeline.Date)
                {
                    switch (oubT.TypeName)
                    {
                        case "4W":
                            counter4WCurrentTime += oubT.Quantity;
                            break;
                        case "6W":
                            counter6WCurrentTime += oubT.Quantity;
                            break;
                        case "10W":
                            counter10WCurrentTime += oubT.Quantity;
                            break;
                        case "20F":
                            counter20FCurrentTime += oubT.Quantity;
                            break;
                        default:
                            counter40FCurrentTime += oubT.Quantity;
                            break;
                    }
                }
                else if (oubT.Date.Date >= from1Timeline.Date && oubT.Date.Date <= to1Timeline.Date)
                {
                    switch (oubT.TypeName)
                    {
                        case "4W":
                            counter4WLastTime += oubT.Quantity;
                            break;
                        case "6W":
                            counter6WLastTime += oubT.Quantity;
                            break;
                        case "10W":
                            counter10WLastTime += oubT.Quantity;
                            break;
                        case "20F":
                            counter20FLastTime += oubT.Quantity;
                            break;
                        default:
                            counter40FLastTime += oubT.Quantity;
                            break;
                    }
                }
            }
            //4W
            outboundTruckChart.Series[0].Points.Add(counter4WLastTime);
            outboundTruckChart.Series[0].Points.Add(counter4WCurrentTime);
            //6W
            outboundTruckChart.Series[1].Points.Add(counter6WLastTime);
            outboundTruckChart.Series[1].Points.Add(counter6WCurrentTime);
            //10W
            outboundTruckChart.Series[2].Points.Add(counter10WLastTime);
            outboundTruckChart.Series[2].Points.Add(counter10WCurrentTime);
            //20F
            outboundTruckChart.Series[3].Points.Add(counter20FLastTime);
            outboundTruckChart.Series[3].Points.Add(counter20FCurrentTime);
            //40F
            outboundTruckChart.Series[4].Points.Add(counter40FLastTime);
            outboundTruckChart.Series[4].Points.Add(counter40FCurrentTime);

            outboundTruckChart.Series[0].Points[0].Label = counter4WLastTime.ToString();
            outboundTruckChart.Series[0].Points[1].Label = counter4WCurrentTime.ToString();

            outboundTruckChart.Series[1].Points[0].Label = counter6WLastTime.ToString();
            outboundTruckChart.Series[1].Points[1].Label = counter6WCurrentTime.ToString();

            outboundTruckChart.Series[2].Points[0].Label = counter10WLastTime.ToString();
            outboundTruckChart.Series[2].Points[1].Label = counter10WCurrentTime.ToString();

            outboundTruckChart.Series[3].Points[0].Label = counter20FLastTime.ToString();
            outboundTruckChart.Series[3].Points[1].Label = counter20FCurrentTime.ToString();

            outboundTruckChart.Series[4].Points[0].Label = counter40FLastTime.ToString();
            outboundTruckChart.Series[4].Points[1].Label = counter40FCurrentTime.ToString();
        }
    }
}
