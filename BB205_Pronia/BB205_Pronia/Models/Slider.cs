using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BB205_Pronia.Models
{
    public class Slider : BaseEntity
    {
        
        [Required,StringLength(25,ErrorMessage ="Uzunluq maxsimum 25 olmalidir")]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        [StringLength(maximumLength:100)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; } 
    }
}
