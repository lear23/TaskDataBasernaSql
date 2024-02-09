

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.ProductsRepo;

public class DirectionRepo : BaseRepo<DirectionsEntity>
{
    public DirectionRepo(ProductDataContext productData) : base(productData)
    {
    }
}
