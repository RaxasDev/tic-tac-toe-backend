using System.Linq.Expressions;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repositories.EF;

public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
{
    protected readonly AppDbContext _dbContext;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void AddRange(List<T> entities)
    {
        _dbContext.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void UpdateRange(List<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public Task<T?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> Get(
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null
    )
    {
        var query = _dbContext.Set<T>().AsQueryable();

        if (expression is not null)
            query = query.Where(expression);

        if (include is not null)
            query = include(query);

        return await query.ToListAsync();
    }

    public async Task<bool> Commit(CancellationToken cancellationToken = default)
    {
        var sucess = await _dbContext.SaveChangesAsync(cancellationToken) > 0;

        return sucess;
    }

    public async Task<T?> FirstAsync(Expression<Func<T, bool>>? where,
        Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync();
    }
}