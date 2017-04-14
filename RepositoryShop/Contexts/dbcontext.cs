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

        public dbcontext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }



        public class StoreDbInitializer : DropCreateDatabaseAlways<dbcontext>
        {
            protected override void Seed(dbcontext db)
            {
                db.Persons.Add(new Person
                {
                    Id = 1,
                    Login = "1",
                    Birthdate = "1",
                    Basket = null,
                    Email = "1",
                    FirstName = "1",
                    LastName = "1",
                    Male = "1",
                    Password = "06d49632c9dc9bcb62aeaef99612ba6b",
                    RegistrationDate = DateTime.Now,
                    Role = "admin"
                });           
            }
        }
    }
}

