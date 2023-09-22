using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class Building
{
    public int BuildingId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<ProductPost> ProductPosts { get; set; } = new List<ProductPost>();
}
