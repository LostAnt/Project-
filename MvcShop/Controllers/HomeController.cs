using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainShop;
using RepositoryShop.IRepositories;
using ServicesShop;
using ServicesShop.Interfaces;
namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IService<Property> _propertyService;
        private readonly IPersonService _personService; 

        public HomeController(ISearchService searchService, IService<Property> propertyService, IPersonService personService)
        {
            _searchService = searchService;
            _propertyService = propertyService;
            _personService = personService;
        }

        public ActionResult Home()
        {
            if (User.Identity.IsAuthenticated)
                return View(new { Name = User.Identity.Name });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchPartial(string city = "", string minPrice = "0", string maxPrice = "20000000",
            string minBeds = "0", string maxBeds = "10", String type = "")
        {
            return PartialView(_searchService.Search(city, minPrice, maxPrice, minBeds, maxBeds, type));
        }

        public ActionResult Search(string city = "")
        {
            return View((Object)city);
        }

        public ActionResult Detail(int id)
        {
            try
            {
                ViewBag.Basket = User.Identity.IsAuthenticated && _personService.GetItem(User.Identity.Name).Basket.Exists(x => x.PropertyId == id);
            }
            catch (NullReferenceException)
            {

                ViewBag.Basket = false;
            }
            return View(_propertyService.GetItem(id));
        }
    }
}