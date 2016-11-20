using System.Data.Entity;
using DomainShop;

namespace RepositoryShop.Contexts
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Person> Persons { get; set; } 
    }
}
