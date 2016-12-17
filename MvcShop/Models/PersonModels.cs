using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class PersonModels
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Brithdate { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}