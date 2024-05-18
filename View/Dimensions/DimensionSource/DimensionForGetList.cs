

namespace Warehouse_IO.View.Dimensions.DimensionSource
{
    public class DimensionForGetList
    {
        public int ID { get; set; }
        public double M3 { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public string UnitOfVolume { get; set; }
        public string Details { get; set; }

        public DimensionForGetList(int id,double m3,double width, double length, double height,string unitofvo,string detail)
        {
            this.ID = id;
            this.M3 = m3;
            this.Width = width;
            this.Length = length;
            this.Height = height;
            this.UnitOfVolume = unitofvo;
            this.Details = detail;
        }
    }
}
