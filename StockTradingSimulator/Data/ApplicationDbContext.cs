using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockTradingSimulator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioTransaction> PortfolioTransactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected void RemoveFixups(ModelBuilder modelBuilder, Type type)
        {
            foreach (var relationship in modelBuilder.Model.FindEntityType(type)!.GetForeignKeys())
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //customizations on tables

            RemoveFixups(modelBuilder, typeof(Trade));
            RemoveFixups(modelBuilder, typeof(Stock));
            RemoveFixups(modelBuilder, typeof(Portfolio));
            RemoveFixups(modelBuilder, typeof(PortfolioTransaction));


            base.OnModelCreating(modelBuilder);
        }
    }
}
