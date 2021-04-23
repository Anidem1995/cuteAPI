using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class WalletDetail
    {
        public int IdDetail { get; set; }
        public int? IdWallet { get; set; }
        public int? IdProperty { get; set; }
        public byte Available { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
        public virtual Wallet IdWalletNavigation { get; set; }
    }
}
