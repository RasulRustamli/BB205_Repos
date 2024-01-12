using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string Title  { get; set; }
        public string Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public int ViewerCount { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreateTime { get; set; }
       public IEnumerable<BlogCategory> BlogCategories { get; set; }
        public IEnumerable<Comment> Comments { get; set; }


    }
}
