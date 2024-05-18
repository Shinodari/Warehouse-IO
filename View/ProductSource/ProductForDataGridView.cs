
namespace Warehouse_IO.View.ProductSource
{
    public class ProductForDataGridView
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public double? M3 { get; set; }
        public double? Weight { get; set; }
        public string Unit { get; set; }
        public string Package { get; set; }

        public ProductForDataGridView(string name, string detail, double? m3, double? weight, string unit, string package)
        {
            this.Name = name;
            this.Details = detail;
            this.M3 = m3;
            this.Weight = weight;
            this.Unit = unit;
            this.Package = package;
        }
    }
}
