using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Acme.Repositories;

/// <summary>
/// Provides base repository functionality for <typeparamref name="TEntity"/>
/// </summary>
public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly AcmeContext Context;
    protected readonly DbSet<TEntity> DbSet;

    /// <summary>Constructor</summary>
    protected RepositoryBase(AcmeContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        DbSet = context.Set<TEntity>();
    }

    /// <summary>Inserts one entity into the database.</summary>
    /// <param name="entity">The entity to add</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    public virtual async Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true)
    {
        await DbSet.AddAsync(entity);
        if (saveChanges)
        {
            await Context.SaveChangesAsync();
        }
        return entity;
    }

    /// <summary>Retrieves all entities from the database.</summary>
    public virtual async Task<List<TEntity>> GetAsync() => await DbSet.ToListAsync();

    /// <summary>Retrieves all entities from the database.</summary>
    public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();
        
    /// <summary>Retrieves all entities with the specified includes.</summary>
    /// <param name="predicate">A where clause predicate</param>
    /// <param name="includes">Foreign key relationships that you would like to include</param>
    public virtual async Task<List<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>> predicate, 
        params Expression<Func<TEntity, object?>>[] includes)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate), "You must specify a predicate!");


        var query = DbSet.Where(predicate);

        if (includes.Any())
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.ToListAsync();
    }

    /// <summary>Returns the first item or null (nothing included).</summary>
    public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await DbSet.FirstOrDefaultAsync(predicate);


    /// <summary>Returns the first item or null  (includes specified relationships).</summary>
    /// <param name="predicate">A where clause predicate</param>
    /// <param name="includes">Relationships to include</param>
    public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object?>>[] includes)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate), "You must specify a predicate!");

        var query = DbSet.Where(predicate);

        if (includes.Any())
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync();
    }

    /// <summary>Deletes one entity from the database.</summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = true)
    {
        DbSet.Remove(entity);
        if (saveChanges)
        {
            await Context.SaveChangesAsync();
        }
    }

    /// <summary>Deletes a list of entity from the database.</summary>
    /// <param name="items">Items to delete</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    public virtual async Task DeleteAsync(List<TEntity> items, bool saveChanges = true)
    {
        foreach (var entity in items)
        {
            DbSet.Remove(entity);
        }

        if (saveChanges)
        {
            await Context.SaveChangesAsync();
        }
    }


    /// <summary>Updates one entity in the database.</summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = true)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;

        if (saveChanges)
        {
            await Context.SaveChangesAsync();
        }
    }
}