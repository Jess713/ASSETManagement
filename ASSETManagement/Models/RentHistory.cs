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
        
        public Guid ID { get; set; }
       
        public DateTime NegotiatedOn { get; set; }
        public string Details { get; set; }
        public Guid personID { get; set; }
        public virtual Asset asset { get; set; }
        public virtual Client person { get; set; }


    }
}