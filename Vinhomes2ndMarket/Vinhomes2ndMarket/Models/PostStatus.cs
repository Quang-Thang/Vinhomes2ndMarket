using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class PostStatus
{
    public Guid PostStatusId { get; set; }

    public string? Status { get; set; }

    public string? Payment { get; set; }

    public Guid? ProductPostId { get; set; }

    public virtual ProductPost? ProductPost { get; set; }
}
