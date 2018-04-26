using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Resource
{
    public class BillingContext : DbContext
    {
        public const string ConnectionString = "name=Billing";
        public BillingContext() : this(ConnectionString)
        {

        }

        private BillingContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<BillingContext>(null);
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
