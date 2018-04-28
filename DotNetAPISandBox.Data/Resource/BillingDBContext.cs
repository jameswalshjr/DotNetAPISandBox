using DotNetAPISandBox.Domain.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DotNetAPISandBox.Data.Resource
{
    public class BillingContext : DbContext, IDatabaseContext
    {
        public const string ConnectionString = "name=DevSandBox";

        public DbSet<FunctionStatusEntity> FunctionStatusEntities { get; set; }

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
            modelBuilder.Entity<FunctionStatusEntity>().HasKey(t => new { t.FunctionStatusId });

        }
    }
}
