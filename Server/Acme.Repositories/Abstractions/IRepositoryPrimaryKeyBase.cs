namespace Acme.Repositories;

public interface IRepositoryPrimaryKeyBase<TEntity, TPrimaryKey> : IRepositoryBase<TEntity> where TEntity : class
{
    /// <summary>Retrieves one entity from the database.</summary>
    /// <param name="id">The primary key</param>
    Task<TEntity> GetAsync(TPrimaryKey id);

    /// <summary>Deletes one entity from the database.</summary>
    /// <param name="id">The primary key</param>
    /// <param name="saveChanges">Indicates if we should save immediately or not</param>
    Task DeleteAsync(TPrimaryKey id, bool saveChanges = true);
}