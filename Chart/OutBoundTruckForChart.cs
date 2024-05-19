using System;

namespace Warehouse_IO.Chart
{
    class OutBoundTruckForChart
    {
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }

        public OutBoundTruckForChart(DateTime date,string typename,int qty)
        {
            this.Date = date;
            this.TypeName = typename;
            this.Quantity = qty;
        }
    }
}
