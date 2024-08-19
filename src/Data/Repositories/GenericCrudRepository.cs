using System.Linq.Expressions;
using BqMedicinaApp.API.src.Data.Repositories.Interfaces.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BqMedicinaApp.API.src.Data.Repositories;

public class GenericCrudRepository<T> : IGenericCrudRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public GenericCrudRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<T>>? GetAll()
    {
        var Entities = await _context.Set<T>().ToListAsync();

        return Entities;
    }

    public async Task<T>? GetById(Expression<Func<T, bool>> predicate)
    {
        var Entity = await _context.Set<T>().FirstOrDefaultAsync(predicate);

        return Entity;
    }

    public async Task<T> CreateEntity(T Entity)
    {
        if (Entity is null)
        {
            throw new ArgumentNullException("Object entered in the parameter is null");
        }

        await _context.AddAsync(Entity);
        await _context.SaveChangesAsync();

        return Entity;
    }

    public async Task<T> DeleteEntity(T Entity)
    {
        if (Entity is null)
        {
            throw new ArgumentNullException("Object entered in the parameter is null");
        }

        _context.Remove(Entity);
        await _context.SaveChangesAsync();

        return Entity;
    }

    public async Task<T> UpdateEntity(T Entity)
    {
        if (Entity is null)
        {
            throw new ArgumentNullException("Object entered in the parameter is null");
        }

        _context.Update(Entity);
        await _context.SaveChangesAsync();

        return Entity;
    }
}