using System;
using System.Collections.Generic;

namespace ShopStoreSport.database;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Category { get; set; }

    public virtual Category? CategoryNavigation { get; set; }
}
