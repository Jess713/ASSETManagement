using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("Occupancy")]
    public class Occupancy
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [StringLength(240)]
        public string Details { get; set; }
        //for the foreign key relationship
        public virtual Guid AssetID { get; set; }
        public virtual Guid ClientID { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Client Client { get; set; }
    }
}