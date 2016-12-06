using System.Data.Entity;
using DomainShop;

namespace RepositoryShop.Contexts
{
    public class PropertyContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
    }
}
