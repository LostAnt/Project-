using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainShop
{
    public class Property
    {
        [Key]
        public long PropertyId { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double LivArea { get; set; }
        public double LandArea { get; set; }
        public long Price { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Describe { get; set; }
        public Person Person { get; set; }
        public long? PersonId { get; set; }
    }
}
