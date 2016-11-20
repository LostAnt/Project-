using System;

namespace DomainShop
{
    public class Purchase
    {
        public long Id { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string Property { get; set; }
        public DateTime Date { get; set; }
         
    }
}