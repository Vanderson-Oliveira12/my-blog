using MyBlog.Context;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.UoW;

namespace MyBlog.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override IUnitOfWork UnitOfWork => _context;
    }
}
