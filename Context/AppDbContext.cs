using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { } 
            
        public DbSet<Category> Categories { get; set; }
    }
}
