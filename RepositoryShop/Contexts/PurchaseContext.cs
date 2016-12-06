using System.Data.Entity;
using DomainShop;

namespace RepositoryShop.Contexts
{
    public class PurchaseContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }
    }
}
