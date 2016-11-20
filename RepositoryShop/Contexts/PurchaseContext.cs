using System.Data.Entity;
using DomainShop;

namespace RepositoryShop.Contexts
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
