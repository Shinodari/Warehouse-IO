
namespace Warehouse_IO.View.StorageFormSource
{
    public class StorageForGetList
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public StorageForGetList(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
