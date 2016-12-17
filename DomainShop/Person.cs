using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DomainShop
{
    public class Person
    {
        [Key]
        public long Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthdate { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Male { get; set; }
    }
}