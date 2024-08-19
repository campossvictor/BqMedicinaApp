using System.Linq.Expressions;

namespace BqMedicinaApp.API.src.Data.Repositories.Interfaces.Generic;

public interface IGenericCrudRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    
    Task<T> GetById(Expression<Func<T, bool>> predicate);

    Task<T> CreateEntity(T Entity);
    
    Task<T> DeleteEntity(T Entity);
    
    Task<T> UpdateEntity(T Entity);
}