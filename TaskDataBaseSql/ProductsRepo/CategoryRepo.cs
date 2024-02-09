

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.ProductsRepo;

public class CategoryRepo : BaseRepo<CategoriesEntity>
{
    public CategoryRepo(ProductDataContext productData) : base(productData)
    {
    }
}
