using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ASSETManagement.Models
{
    [Table("Appliance")]
    public class Appliance
    {
        public Guid ApplianceID { get; set; }

        public string ApplianceType { get; set; }


      
    }
}