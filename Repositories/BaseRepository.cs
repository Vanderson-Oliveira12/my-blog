using Microsoft.EntityFrameworkCore;
using MyBlog.Context;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {

        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> CreateAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<T> UpdateAsync(T model)
        {

            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();

            return model;
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

            if ( item != null )
            {

                _context.Set<T>().Remove(item);

                await _context.SaveChangesAsync();
            }
        }
    }
}
