using System;
using System.Collections.Generic;
using System.Linq;
using DomainShop;
using RepositoryShop.IRepositories;

namespace ServicesShop
{
    public class SearchService : ISearchService
    {
        private readonly IRepository<Property> _propertyRepository;
        public SearchService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public IEnumerable<Property> Search(string query, string minPrice, string maxPrice, string minBeds, string maxBeds, string type)
        {
            var entries = _propertyRepository.
    GetItemList().
    Where(x => x.City.Contains(query)
    && x.Price >= Int32.Parse(minPrice)
    && x.Price <= Int32.Parse(maxPrice)
    && x.Bedrooms >= Int32.Parse(minBeds)
    && x.Bedrooms <= Int32.Parse(maxBeds)
).ToList();
            return entries;
        }
    }
}
