using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("Service")]
    public class Service
    {

        [Key]
        public Guid serviceID { get; set; }
        
        public string serviceType { get; set; }
        public double price { get; set; }

    }
}