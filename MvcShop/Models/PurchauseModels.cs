using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MvcShop.Models
{
    public class PurchauseModels 
    {
        public long Id { get; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public string Property { get; set; }
        public DateTime Date { get; }
    }
}