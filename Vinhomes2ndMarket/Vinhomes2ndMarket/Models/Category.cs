using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProductPost> ProductPosts { get; set; } = new List<ProductPost>();
}
