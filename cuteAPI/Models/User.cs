using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class User
    {
        public User()
        {
            Collections = new HashSet<Collection>();
            LeasingContractIdEmployeeNavigations = new HashSet<LeasingContract>();
            LeasingContractIdUserNavigations = new HashSet<LeasingContract>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<LeasingContract> LeasingContractIdEmployeeNavigations { get; set; }
        public virtual ICollection<LeasingContract> LeasingContractIdUserNavigations { get; set; }
    }
}
