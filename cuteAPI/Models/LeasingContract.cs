using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class LeasingContract
    {
        public LeasingContract()
        {
            CollectionDetails = new HashSet<CollectionDetail>();
        }

        public int IdContract { get; set; }
        public int IdUser { get; set; }
        public int IdEmployee { get; set; }
        public int IdProperty { get; set; }
        public decimal MonthlyRent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User IdEmployeeNavigation { get; set; }
        public virtual Property IdPropertyNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<CollectionDetail> CollectionDetails { get; set; }
    }
}
