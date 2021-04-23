using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class Collection
    {
        public Collection()
        {
            CollectionDetails = new HashSet<CollectionDetail>();
        }

        public int IdCollection { get; set; }
        public int IdUser { get; set; }
        public decimal Debt { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<CollectionDetail> CollectionDetails { get; set; }
    }
}
