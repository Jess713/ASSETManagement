using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASSETManagement.Models
{
    [Table("FullAddress")]
    public class FullAddress
    {
        
        public Guid ID { get; set; }
        public string UnitNum { get; set; }
        public string StreetAddress { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public string Fulladdress
        {
            get
            {
                return String.Format("{0} {1}, {2}, {3} {4}", UnitNum, StreetAddress, Province, Country, PostalCode); 
            }
        }
    }
}