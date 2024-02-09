

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.ProductsRepo;

public class ClientsRepo : BaseRepo<ClientsEntity>
{
    public ClientsRepo(ProductDataContext productData) : base(productData)
    {
    }
}
