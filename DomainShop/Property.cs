using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainShop
{
    public class Property
    {
        public long Id;
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double LivArea { get; set; }
        public double LandArea { get; set; }
        public long Price { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
