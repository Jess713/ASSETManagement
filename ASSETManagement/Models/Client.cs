using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//Tutorial:
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/adding-a-model
namespace ASSETManagement.Models
{
    [Table("Customers")]
    public class Client : Person
    {
       public Guid ClientID { get; set; }

       public virtual Asset Asset { get; set; }
       public virtual ICollection<Occupancy> OccupancyHistory { get; set; }
       public virtual ICollection<RentHistory> RentalHistory { get; set; }
    }
  
}