using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Description).IsRequired();
            builder.HasOne(b => b.AppUser)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.AppUserId);
            builder.Property(b=>b.CreateTime)
                .HasDefaultValueSql("Getutcdate()");
            builder.Property(b => b.ViewerCount)
                .HasDefaultValue(0);

        }
    }
}
