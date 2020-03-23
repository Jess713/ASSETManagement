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
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public FullAddress HomeAddress { get; set; }
        public FullAddress WorkAddress { get; set; }


    }
}