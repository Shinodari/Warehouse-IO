using System;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    class OutboundActivity
    {
        public DateTime Date { get; set; }
        public string Invoice { get; set; }
        public string Customer { get; set; }
        public string DeliveryPlace { get; set; }
        public string Truck { get; set; }
        public string Details { get; set; }
        public bool Export { get; set; }
        public int OutboundID { get; set; }
        public double M3 { get; set; }


        public OutboundActivity(DateTime date, string invoice, string customer, string deliveryplace, string truck, string detail,bool isinter, int outboundid,double m3)
        {
            this.Date = date;
            this.Invoice = invoice;
            this.Customer = customer;
            this.DeliveryPlace = deliveryplace;
            this.Truck = truck;
            this.Details = detail;
            this.Export = isinter;
            this.OutboundID = outboundid;
            this.M3 = m3;
        }
    }
}
