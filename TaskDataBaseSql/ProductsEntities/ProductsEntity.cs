using System;
using System.Collections.Generic;

namespace TaskDataBaseSql.ProductsEntities;

public partial class ProductsEntity
{
    public int Id { get; set; }

    public string? ModelName { get; set; }

    public string? Color { get; set; }

    public int? CategoryId { get; set; }

    public virtual CategoriesEntity? Category { get; set; }
}
