using System.Data.Entity;
using DomainShop;

namespace RepositoryShop.Contexts
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } 
    }
}
