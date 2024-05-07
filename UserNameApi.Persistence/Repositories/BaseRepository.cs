using Microsoft.EntityFrameworkCore;
using UserNameApi.Models.DbModels;
using UserNameApi.Persistence.Interfaces;

namespace UserNameApi.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : WorkoutDbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    } 

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);
        if(entity == null)
        {
            return entity;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
