using BB205_test.Entities.Base;

namespace BB205_test.Entities
{
    public class Category:BaseEntity
    {
        
        public string  Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
    }
}
