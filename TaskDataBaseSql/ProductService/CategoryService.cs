

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;
using TaskDataBaseSql.ProductsEntities;
using TaskDataBaseSql.ProductsRepo;

namespace TaskDataBaseSql.ProductService;

public class CategoryService
{
    private readonly CategoryRepo _categoryRepo;

    public CategoryService(CategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public CategoriesEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepo.Get(x => x.CategoryName == categoryName );
            if (categoryEntity == null)
            {
                {
                    categoryEntity = _categoryRepo.Create(new CategoriesEntity
                    {
                        CategoryName = categoryName,
                     
                    });
                }
            }
            return categoryEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateCategoryervice :: " + ex.Message); }
        return null!;
    }
    public CategoriesEntity GetCategoryByName(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepo.Get(x => x.CategoryName == categoryName );
            return categoryEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetCategoryService :: " + ex.Message); }
        return null!;
    }

    public CategoriesEntity GetCategoryById(int id)
    {
        try
        {
            var categoryEntity = _categoryRepo.Get(x => x.Id == id);
            return categoryEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdCategoryService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<CategoriesEntity> GetAllCategories()
    {
        try
        {
            var categories = _categoryRepo.GetAll();
            return categories;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllCategoryService :: " + ex.Message); }
        return null!;
    }


    public CategoriesEntity UpdateCategory(CategoriesEntity categoryEntity)
    {
        try
        {
            var updateCategory = _categoryRepo.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updateCategory;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateRoleService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteCategory(int id)
    //{
    //    try
    //    {
    //        _categoryRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteCategoryService :: " + ex.Message); }

    //}


    public bool DeleteCategory(Expression<Func<CategoriesEntity, bool>> expression)
    {
        try
        {
            var result = _categoryRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteACategoryService :: " + ex.Message); }
        return false;

    }




}
