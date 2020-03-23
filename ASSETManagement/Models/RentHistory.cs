using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("RentHistory")]
    public class RentHistory
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Asset")]
        public Guid AssetID { get; set; }
        [ForeignKey("Client")]
        public Guid ClientID { get; set; }
        public DateTime NegotiatedOn { get; set; }
        public string Details { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Client Client { get; set; }


    }
}