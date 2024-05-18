using System;

namespace Warehouse_IO.View.In_Out_ActivityForm
{
    public class InboundActivity
    {
        public DateTime Date { get; set; }
        public string Invoice { get; set; }
        public string Customer { get; set; }
        public string Storage { get; set; }
        public string Truck { get; set; }
        public string Details { get; set; }
        public bool Import { get; set; }
        public int StorageID { get; set; }
        public int InboundID { get; set; }

        public InboundActivity(DateTime date, string invoice, string customer, string storage,string truck,string detail,bool import,int storageid,int inboundid)
        {
            this.Date = date;
            this.Invoice = invoice;
            this.Customer = customer;
            this.Storage = storage;
            this.Truck = truck;
            this.Details = detail;
            this.Import = import;
            this.StorageID = storageid;
            this.InboundID = inboundid;
        }        
    }

}
