
namespace Warehouse_IO.View.Transport.SupplierFormSource
{
    public class SupplierForGetList
    {
        public int ID { get; set; }
        public string name { get; set; }

        public SupplierForGetList(int id,string name)
        {
            this.ID = id;
            this.name = name;
        }
    }
}
