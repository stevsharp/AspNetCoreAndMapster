using System.Linq.Expressions;

namespace AspNetCoreAndMapster.Specification;

public class NullSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>>? Criteria => null;
    public List<Expression<Func<T, object>>> Includes { get; } = new();
}