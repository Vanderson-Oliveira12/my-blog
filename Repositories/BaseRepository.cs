using Microsoft.EntityFrameworkCore;
using MyBlog.Context;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.UoW;
using System.Collections.Generic;

namespace MyBlog.Repositories;
public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    public abstract IUnitOfWork UnitOfWork { get; }

    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        => _dbSet.Where(entity => entity.Id == id).AsNoTracking().FirstOrDefault();

    public void Create(T model)
        => _dbSet.Add(model);

    public void Update(T model)
        => _dbSet.Update(model);

    public void Delete(T model)
        => _dbSet.Remove(model);

    //MEotdo de uma linha retorna arrow function

}
