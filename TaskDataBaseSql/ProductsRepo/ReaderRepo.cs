

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.ProductsRepo;

public class ReaderRepo : BaseRepo<ReadersEntity>
{
    public ReaderRepo(ProductDataContext productData) : base(productData)
    {
    }
}