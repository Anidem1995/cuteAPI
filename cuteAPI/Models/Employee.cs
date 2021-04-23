using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Users = new HashSet<User>();
            Wallets = new HashSet<Wallet>();
        }

        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public int? CommisionPercentage { get; set; }
        public DateTime HiringDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
