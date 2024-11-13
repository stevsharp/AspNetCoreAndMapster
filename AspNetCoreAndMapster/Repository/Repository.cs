using AspNetCoreAndMapster.Models;
using AspNetCoreAndMapster.Specification;

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAndMapster.Repository
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        private readonly AppDbContext _context = context;

        public async Task<T?> GetByIdAsync(int id, CancellationToken token) =>
            await _context.Set<T>().FindAsync(id,token);

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification, CancellationToken token)
        {
            var query = ApplySpecification(specification);

            return await query.ToListAsync(token);
        }

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _context.Set<T>().AddAsync(entity,token);

            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(T entity, CancellationToken token)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(token);
        }

        public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken token)
        {
            var query = ApplySpecification(specification);
            return await query.CountAsync(token);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) =>
            SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}