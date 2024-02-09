using System;
using System.Collections.Generic;

namespace TaskDataBaseSql.ProductsEntities;

public partial class ClientsEntity
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? ReaderId { get; set; }

    public int? DirectionId { get; set; }

    public virtual DirectionsEntity? Direction { get; set; }

    public virtual ReadersEntity? Reader { get; set; }
}
