using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("Asset")]
    public class Asset
    {
        public Guid AssetID { get; set; }

        public  Nullable<Guid> ApplianceID { get; set; }
        public Nullable<Guid> ServiceID { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public virtual FullAddress Address { get; set; }
        public string AskingRent { get; set; }
        public virtual ICollection<Occupancy> OccupancyHistory { get; set; }
        public virtual ICollection<RentHistory> RentalHistory { get; set; }
        public virtual Appliance Appliances { get; set; }
        public virtual Service Services { get; set; }
    }
}