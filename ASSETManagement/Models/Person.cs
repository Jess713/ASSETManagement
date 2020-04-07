using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("Person")]
    public class Person
    {
   
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual FullAddress HomeAddress { get; set; }
        public virtual FullAddress WorkAddress { get; set; }


    }
}