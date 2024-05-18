
namespace Warehouse_IO.View.DepartmentFormSource
{
    public class DepartmentForGetList
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Storgae { get; set; }

        public DepartmentForGetList(int id, string name,string storgae)
        {
            this.DepartmentID = id;
            this.DepartmentName = name;
            this.Storgae = storgae;
        }
    }
}
