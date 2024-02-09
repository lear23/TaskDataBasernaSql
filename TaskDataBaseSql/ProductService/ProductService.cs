

using System.Diagnostics;
using TaskDataBaseSql.ProductsEntities;
using TaskDataBaseSql.ProductsRepo;


namespace TaskDataBaseSql.ProductService;

public class ProductService
{

    private readonly ProductRepo _product;
    private readonly CategoryService _categoryService;

    public ProductService(ProductRepo product, CategoryService categoryService)
    {
        _product = product;
        _categoryService = categoryService;
    }

    public ProductsEntity CreateProduct(string modelName, string color, string categoryName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);
        var userEntity = new ProductsEntity
        {
            ModelName = modelName,
            Color = color,
            CategoryId = categoryEntity.Id
        };
        userEntity = _product.Create(userEntity);
        return userEntity;
    }

    public ProductsEntity GetProductById(int id)
    {
        try
        {
            var result = _product.Get(x => x.Id == id);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdProductService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<ProductsEntity> GetAllProducts()
    {
        try
        {
            var products = _product.GetAll();
            return products;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllProductsService :: " + ex.Message); }
        return null!;
    }


    public ProductsEntity UpdateProduct(ProductsEntity productEntity)
    {
        try
        {
            var updateProduct = _product.Update(x => x.Id == productEntity.Id, productEntity);
            return updateProduct;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateProductService :: " + ex.Message); }
        return null!;
    }

    public void DeleteProduct(int id)
    {
        try
        {
            _product.Delete(x => x.Id == id);

        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteProductService :: " + ex.Message); }

    }


    //public bool DeleteProduct(Expression<Func<ProductsEntity, bool>> expression)
    //{
    //    try
    //    {
    //        var result = _product.Delete(expression);
    //        return result;
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteProductService :: " + ex.Message); }
    //    return false;

    //}





}
