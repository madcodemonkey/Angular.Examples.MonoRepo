using System.Linq.Expressions;

namespace Acme.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    /// <summary>Inserts one entity into the database.</summary>
    /// <param name="entity">The entity to add</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true);

    /// <summary>Retrieves all entities from the database.</summary>
    Task<List<TEntity>> GetAsync();

    /// <summary>Retrieves all entities from the database.</summary>
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>Returns the first item or null (nothing included).</summary>
    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>Returns the first item or null  (includes specified relationships).</summary>
    /// <param name="predicate">A where clause predicate</param>
    /// <param name="includes">Relationships to include</param>
    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object?>>[] includes);
    
    /// <summary>Deletes one entity from the database.</summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    Task DeleteAsync(TEntity entity, bool saveChanges = true);

    /// <summary>Deletes a list of entity from the database.</summary>
    /// <param name="items">Items to delete</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    Task DeleteAsync(List<TEntity> items, bool saveChanges = true);

    /// <summary>Updates one entity in the database.</summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    Task UpdateAsync(TEntity entity, bool saveChanges = true);
}