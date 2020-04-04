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
        public string Name { get; set; }
        public string Type { get; set; }
        
        public FullAddress Address { get; set; }
        public string AskingRent { get; set; }
        public virtual ICollection<Occupancy> OccupancyHistory { get; set; }

        public virtual ICollection<RentHistory> RentalHistory { get; set; }

        public virtual ICollection<Appliance> Appliances { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual Person Person { get; set; } //set relationship between asset<->customer

    }
}