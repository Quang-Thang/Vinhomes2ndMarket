using System;
using System.Collections.Generic;

namespace Vinhomes2ndMarket.Models;

public partial class Wallet
{
    public int WalletId { get; set; }

    public Guid? AccountId { get; set; }

    public decimal? Balance { get; set; }

    public virtual Account? Account { get; set; }
}
