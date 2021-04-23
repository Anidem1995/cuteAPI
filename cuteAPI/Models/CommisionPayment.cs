using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class CommisionPayment
    {
        public int IdEmployee { get; set; }
        public int IdContract { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Date { get; set; }

        public virtual LeasingContract IdContractNavigation { get; set; }
        public virtual User IdEmployeeNavigation { get; set; }
    }
}
