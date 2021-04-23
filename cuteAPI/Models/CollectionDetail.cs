using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class CollectionDetail
    {
        public int IdMovement { get; set; }
        public int IdCollection { get; set; }
        public int? IdContract { get; set; }
        public string MovementType { get; set; }
        public decimal Ammount { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Collection IdCollectionNavigation { get; set; }
        public virtual LeasingContract IdContractNavigation { get; set; }
    }
}
