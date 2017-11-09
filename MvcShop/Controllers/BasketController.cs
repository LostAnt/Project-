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
            {
                if (PeS.GetItem(HttpContext.User.Identity.Name).Basket != null)
                    return View(PeS.GetItem(User.Identity.Name).Basket);
                else return View("EmptyBasket");                                                                   // Доделать
            }
            else
                return RedirectToAction("Login", "Account");
        }

        //   POST: Admin/Create
        public ActionResult Buy(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (PeS.GetItem(User.Identity.Name).Basket == null)
                {
                    PeS.GetItem(User.Identity.Name).Basket = new List<Property>();
                    PeS.GetItem(User.Identity.Name).Basket.Add(PS.GetItem(id));
                    return RedirectToAction("Detail", "Home", new { id = id });
                }
                else
                {
                    bool are = false;
                    foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                        if (s.PropertyId == id) are = true;                                               // Проверка на наличие в корзине
                    if (are == false) PeS.GetItem(User.Identity.Name).Basket.Add(PS.GetItem(id));
                }
                bool are2 = false;
                foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                    if (s.PropertyId == id) are2 = true;
                if (are2 == false) PeS.GetItem(User.Identity.Name).Basket.Add(PS.GetItem(id));

                return RedirectToAction("Detail", "Home", new { id = id });
            }
            else { return RedirectToAction("Login", "Account"); Buy(id); }

        }

        public ActionResult Delete(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                    if (s.PropertyId == id)
                    {
                        PeS.GetItem(User.Identity.Name).Basket.Remove(s);
                        return RedirectToAction("Detail", "Home", new { id = id });
                    }
                return View();
            }
            else
                return RedirectToAction("Login", "Account");
        }

        public ActionResult DeleteFromBasket(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                foreach (var s in PeS.GetItem(User.Identity.Name).Basket)
                    if (s.PropertyId == id)
                    {
                        PeS.GetItem(User.Identity.Name).Basket.Remove(s);
                        return RedirectToAction("Index", "Basket");
                    }
                return View();
            }
            else
                return RedirectToAction("Login", "Account");
        }

    }
}
