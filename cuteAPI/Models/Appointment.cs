using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class Appointment
    {
        public int IdUser { get; set; }
        public int IdEmployee { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string UserObservations { get; set; }
        public string EmployeeObservations { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
