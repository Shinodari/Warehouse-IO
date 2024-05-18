

namespace Warehouse_IO.View.Transport.TruckFormSource
{
    public class TruckForGetList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TruckForGetList(int id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
