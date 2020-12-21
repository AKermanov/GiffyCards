namespace GiffyCards.Web.ViewModels.Sizes
{
   public class ShapeAndSizeViewModel
    {
        public int Id { get; set; }

        public string ShapeName { get; set; }

        public string Lenght { get; set; }

        public string RingRange { get; set; }

        public override bool Equals(object obj)
        {
            return ((ShapeAndSizeViewModel)obj).ShapeName == this.ShapeName;
        }

        public override int GetHashCode()
        {
            return this.ShapeName.GetHashCode();
        }
    }
}
