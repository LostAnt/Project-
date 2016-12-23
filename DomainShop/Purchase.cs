using System;

namespace DomainShop
{
    public class Purchase
    {
        public long Id { get; set; }
        public string Property { get; set; }
        public DateTime Date { get; set; }
        public Person Buyer { get; set; }
        public Person Seller { get; set; }
        public long? BuyerId { get; set; }
        public long? SellerId { get; set; }     
    }
} 