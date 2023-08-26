﻿using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly ECommerceDbContext _context;

    public WriteRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> models)
    {
        await Table.AddRangeAsync(models);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Remove(model);
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public bool Remove(List<T> models)
    {
        Table.RemoveRange(models);
        return true;
    }
}
