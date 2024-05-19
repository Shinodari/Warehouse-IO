using System;

namespace Warehouse_IO.Chart
{
    public class InboundTruckForChart
    {
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }

        public InboundTruckForChart(DateTime date,string typename,int qty)
        {
            this.Date = date;
            this.TypeName = typename;
            this.Quantity = qty;
        }
    }
}
