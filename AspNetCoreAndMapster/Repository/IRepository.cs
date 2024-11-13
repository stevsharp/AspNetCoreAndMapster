using AspNetCoreAndMapster.Specification;
namespace AspNetCoreAndMapster.Repository;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, CancellationToken token);

    Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token);
    Task AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken token);
}
