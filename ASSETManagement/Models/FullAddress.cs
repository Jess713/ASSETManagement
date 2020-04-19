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
        [RegularExpression("([0-9]+)")] 
        public string UnitNum { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Max 40 digits")]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Postal Code should be at least 6 character length.")]
        [StringLength(6, ErrorMessage = "Max 6 digits")]
        [DataType(DataType.PostalCode)]
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
