using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class EmployeeRole
    {
        public int IdEmployee { get; set; }
        public int IdRole { get; set; }
        public byte Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
