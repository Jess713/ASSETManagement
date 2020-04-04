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

       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Details { get; set; }

        //for the foreign key relationship
        public virtual Asset Asset { get; set; }
        public virtual Client Client { get; set; }
    }
}