using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASSETManagement.Data
{
    public class AppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public AppContext() : base("name=AppContext")
        {
        }

        public System.Data.Entity.DbSet<ASSETManagement.Models.Appliance> Appliances { get; set; }

        public System.Data.Entity.DbSet<ASSETManagement.Models.Asset> Assets { get; set; }

        public System.Data.Entity.DbSet<ASSETManagement.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<ASSETManagement.Models.FullAddress> FullAddresses { get; set; }

        public System.Data.Entity.DbSet<ASSETManagement.Models.Occupancy> Occupancies { get; set; }

        public System.Data.Entity.DbSet<ASSETManagement.Models.Person> People { get; set; }
        public System.Data.Entity.DbSet<ASSETManagement.Models.RentHistory> RentHistories { get; set; }
        public System.Data.Entity.DbSet<ASSETManagement.Models.Service> Services { get; set; }

    }

    public class AppDBInitializer : CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            base.Seed(context); //This is empty for now, but expected to have sample records later.
        }
    }
}
