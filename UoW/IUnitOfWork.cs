namespace MyBlog.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int SaveChanges();
        void Commit();
        void Rollback();
        Task BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task CommitAsync();
        Task RollbackAsync();
    }
}
