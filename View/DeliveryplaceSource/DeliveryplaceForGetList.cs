
namespace Warehouse_IO.View.DeliveryplaceSource
{
    public class DeliveryplaceForGetList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DeliveryplaceForGetList(int id,string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
