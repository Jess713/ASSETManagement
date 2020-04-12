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

        public string ServiceType { get; set; }
        public double price { get; set; }

    }
}