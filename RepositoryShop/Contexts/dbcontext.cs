using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainShop;

namespace RepositoryShop.Contexts
{
  public class dbcontext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
