using DomainShop;
using ServicesShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class BasketController : Controller
    {
        IPersonService PeS;
        IService<Property> PS;

        public BasketController(IPersonService PeS, IService<Property> PS)
        {
            this.PeS = PeS;
            this.PS = PS;
        }

        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View(PeS.GetItem(User.Identity.Name).Basket);
            else
                return View("Требуется авторизация"); 
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                {
                    if (s.PropertyId == id)
                        return View(s);
                }
                return View();
            }
            else
                return View("Требуется авторизация");

        }
        //   GET: Admin/Create
        public ActionResult Buy()
        {

            if (HttpContext.User.Identity.IsAuthenticated) return View();
            else
                return View("Требуется авторизация");

        }

        //   POST: Admin/Create
        [System.Web.Mvc.HttpPost]
        public ActionResult Buy(Property item)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                try
                {
                 //   PeS.GetItem(User.Identity.Name).Basket.Add(PS.GetItem(1));
                    PeS.GetItem(User.Identity.Name).Basket.Add(item);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            else
                return View("Требуется авторизация");
        }

        //// GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}
        public ActionResult Delete()
        {
            if (HttpContext.User.Identity.IsAuthenticated) return View();
            else
                return View("Требуется авторизация");
        }

        // POST: Admin/Delete/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                    if (s.PropertyId == id)
                    {
                        PeS.GetItem(User.Identity.Name).Basket.Remove(s);
                        return RedirectToAction("Index");
                    }
                return View();
            }
            else
                return View("Требуется авторизация");
        }

    }
}
