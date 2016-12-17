using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainShop;
using RepositoryShop.IRepositories;

namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public HomeController(IPersonRepository repository)
        {
            _personRepository = repository;
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

        public ActionResult Search()
        {

            return View();
        }
    }
}