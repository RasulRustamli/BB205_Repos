using System.ComponentModel.DataAnnotations;

namespace BB205_Pronia.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(maximumLength:10,ErrorMessage ="Uzunlugu astiniz")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
