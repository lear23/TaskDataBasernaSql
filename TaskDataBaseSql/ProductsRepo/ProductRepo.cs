

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.ProductsRepo;

public class ProductRepo : BaseRepo<ProductsEntity>
{
    public ProductRepo(ProductDataContext productData) : base(productData)
    {
    }
}
