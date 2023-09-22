using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public bool? Gender { get; set; }

    public int? RoleId { get; set; }

    public int? BuildingId { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductPost> ProductPosts { get; set; } = new List<ProductPost>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
