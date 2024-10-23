using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using MyBlog.UoW;

namespace MyBlog.Context
{
    public class AppDbContext : DbContext, IUnitOfWork
    {

        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { } 
            
        public DbSet<Category> Categories { get; set; }

        public void BeginTransaction() 
            => Database.BeginTransaction();
        public async Task BeginTransactionAsync()
            => await Database.BeginTransactionAsync();

        public void Commit() 
            => Database.CommitTransaction();

        public async Task CommitAsync() 
            => await Database.CommitTransactionAsync();

        public void Rollback()
             => Database.RollbackTransaction();

        public async Task RollbackAsync() 
            => await Database.RollbackTransactionAsync();
    }
}
