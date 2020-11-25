using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogExample;

namespace BlogExample.Data
{
    public class BlogsContext : DbContext
    {
        public BlogsContext (DbContextOptions<BlogsContext> options)
            : base(options)
        {
        }


        public DbSet<BlogExample.Blog> Blogs { get; set; }
        public DbSet<BlogExample.Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)
                .WithOne();

            modelBuilder.Entity<Blog>()
                .Navigation(b => b.Posts)
                    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
