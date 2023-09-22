using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class ProductPost
{
    public Guid ProductPostId { get; set; }

    public Guid? AccountId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? LastUpdateAt { get; set; }

    public decimal? Price { get; set; }

    public int? BuildingId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Building? Building { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PostStatus> PostStatuses { get; set; } = new List<PostStatus>();
}
