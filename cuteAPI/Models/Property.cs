using System;
using System.Collections.Generic;

#nullable disable

namespace cuteAPI.Models
{
    public partial class Property
    {
        public Property()
        {
            LeasingContracts = new HashSet<LeasingContract>();
            WalletDetails = new HashSet<WalletDetail>();
        }

        public int IdProperty { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double NumberOfBaths { get; set; }
        public int NumberOfRooms { get; set; }
        public byte Garage { get; set; }
        public double SurfaceInSquareMeters { get; set; }
        public string Description { get; set; }

        public decimal MonthlyRent { get; set; }

        public virtual ICollection<LeasingContract> LeasingContracts { get; set; }
        public virtual ICollection<WalletDetail> WalletDetails { get; set; }
    }
}
