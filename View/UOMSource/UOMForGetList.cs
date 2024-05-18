
namespace Warehouse_IO.View.UOMSource
{
    public class UOMForGetList
    {
        public int ID { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Package { get; set; }
        public string Details { get; set; }

        public UOMForGetList(int id,double quantity,string unit,string pack,string detail)
        {
            this.ID = id;
            this.Quantity = quantity;
            this.Unit = unit;
            this.Package = pack;
            this.Details = detail;
        }
    }
}
