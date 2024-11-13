using AspNetCoreAndMapster.Models;

using System.Linq.Expressions;

namespace AspNetCoreAndMapster.Specification;


public class ItemsByNameSpecification : ISpecification<Item>
{
    public Expression<Func<Item, bool>>? Criteria { get; }
    public List<Expression<Func<Item, object>>> Includes { get; } = new();

    public ItemsByNameSpecification(string name)
    {
        Criteria = item => item.Name.Contains(name);
    }
}
