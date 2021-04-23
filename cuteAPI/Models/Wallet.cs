using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            WalletDetails = new HashSet<WalletDetail>();
        }

        public int IdWallet { get; set; }
        public int? IdEmployee { get; set; }
        public int Size { get; set; }
        public int AvailableProps { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<WalletDetail> WalletDetails { get; set; }
    }
}
