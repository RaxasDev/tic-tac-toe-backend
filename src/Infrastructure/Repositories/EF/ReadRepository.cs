using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Repositories.EF;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _dbContext;
    protected readonly IQueryable<T> _query;

    public ReadRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = dbContext.Set<T>();
    }

    public IQueryable<T> Queryable() => _query.AsQueryable().AsNoTracking();

    public async Task<T?> FirstAsync(
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
    )
    {
        var query = _query.AsNoTracking();

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<T>> Get(
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        string order = null
    )
    {
        var query = _query.AsNoTracking().AsQueryable();

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<VM>> Select<VM>(
        Expression<Func<T, VM>> selector,
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        string? order = null
    ) where VM : class
    {
        var query = _query.AsNoTracking().AsQueryable();

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.Select(selector).ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
    {
        var query = _query.AsNoTracking();

        if (where is not null)
            query = query.Where(where);

        return await query.CountAsync();
    }

    public async Task<List<VM>> SelectPaginatedAsync<VM>(
        Expression<Func<T, VM>> selector,
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? where = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        string? order = null
    ) where VM : class
    {
        var query = _query.AsNoTracking().AsQueryable();

        if (where is not null)
            query = query.Where(where);

        if (include is not null)
            query = include(query);

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        var skip = (pageNumber - 1) * pageSize;

        return await query
            .Skip(skip)
            .Take(pageSize)
            .Select(selector)
            .ToListAsync();
    }
}