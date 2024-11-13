using AspNetCoreAndMapster.Models;

using System.Linq.Expressions;

namespace AspNetCoreAndMapster.Specification
{
    public class ItemsByPriceRangeSpecification : ISpecification<Item>
    {
        public Expression<Func<Item, bool>>? Criteria { get; }
        public List<Expression<Func<Item, object>>> Includes { get; } = new();

        public ItemsByPriceRangeSpecification(decimal minPrice, decimal maxPrice)
        {
            Criteria = item => item.Price >= minPrice && item.Price <= maxPrice;
        }
    }
}