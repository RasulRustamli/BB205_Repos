using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Comment:BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int? ParentId { get; set; }
        public Comment? Parent { get; set; } 
        public IEnumerable<Comment>? Children { get; set; }
    }
}
