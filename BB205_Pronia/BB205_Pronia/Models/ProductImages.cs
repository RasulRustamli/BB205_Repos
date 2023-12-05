namespace BB205_Pronia.Models
{
    public class ProductImages: BaseEntity
    {
     
        public string ImgUrl { get; set; }
        public bool? IsPrime { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
