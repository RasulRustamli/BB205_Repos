using BB205_Pronia.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace BB205_Pronia.Models
{
    public class Category:BaseEntity
    {
        
        [StringLength(maximumLength:10,ErrorMessage ="Uzunlugu astiniz")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
