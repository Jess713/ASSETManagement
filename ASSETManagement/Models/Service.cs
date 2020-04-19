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

        public Guid ServiceID { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Max 60 digits")]
        public string ServiceType { get; set; }
        [Range(0, 10000)]
        public double price { get; set; }

    }
}