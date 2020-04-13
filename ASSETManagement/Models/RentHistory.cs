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
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime NegotiatedOn { get; set; }
        public string Details { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Person Person { get; set; }


    }
}