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
      //public dbcontext():base("dbcontext")
      //{

      //}
        public DbSet<Person> Persons { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public dbcontext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        //public dbcontext(string connectionString)
        //    : base(connectionString)
        //{
        //}

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
               // db.Properties.Add(new Property({}))


                //public long Id { get; set; }
                //public string Login { get; set; }
                //public string FirstName { get; set; }
                //public string LastName { get; set; }
                //public string Email { get; set; }
                //public string Password { get; set; }
                //public string Birthdate { get; set; }
                //public string Role { get; set; }
                //public DateTime RegistrationDate { get; set; }
                //public string Male { get; set; }

                //db.Roles.Add(new Role { Id = 1, Name = "admin" });
                //db.Roles.Add(new Role { Id = 2, Name = "user" });
                //db.Vids.Add(new Vid { Id = 1, Name = "Phone" });
                //db.Vids.Add(new Vid { Id = 2, Name = "Smartphone" });
                //db.Products.Add(new Product { Id = 1, Name = "iPhone 7", Company = "Apple", Price = 320, IdVid = 1 });
                //db.Users.Add(new User { Id = 1, Name = "Mad", Password = "1488", RoleId = 1 });

            }
        }
    }
}
