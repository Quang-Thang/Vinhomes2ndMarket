using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid? ProductPostId { get; set; }

    public Guid? AccountId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public decimal? Total { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ProductPost? ProductPost { get; set; }
}
