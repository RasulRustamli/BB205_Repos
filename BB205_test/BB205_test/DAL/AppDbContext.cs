using BB205_test.Entities;
using Microsoft.EntityFrameworkCore;

namespace BB205_test.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
