using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Core;
using DomainShop;
using ServicesShop.Service;
using ServicesShop.Interfaces;
using System.Web.Security;

namespace MvcShop.Controllers
{
    public class AdminController : Controller
    {
        IService<Property> PS;
        IPersonService PeS;
        public AdminController(IService<Property> PS,IPersonService PeS)
        {
            this.PS = PS;
           this.PeS = PeS;
           // if (HttpContext.User.Identity.IsAuthenticated) ErroreRole();
            //  ErroreRole();
        }
        // GET: Admin
        public ActionResult Index()
        {
            if ((PeS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PeS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            return View(PS.GetItemList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if ((PeS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PeS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            return View(PS.GetItem(id));
        }

     //   GET: Admin/Create
        public ActionResult Create()
        {

            if ((PeS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PeS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            else
                return View();

        }

     //   POST: Admin/Create
       [HttpPost]
        public ActionResult Create(Property item)
        {
            try
            {
                // TODO: Add insert logic here
                PS.Create(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        //public ActionResult Edit(Property id)
        //{
        //    PS.Update(id);
        //    return View();
        //}
        public ActionResult Edit(int id)
        {
            if ((PeS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PeS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            else
                return View(PS.GetItem(id));
        }
        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Property item)
        {
            try
            {
                // TODO: Add update logic here
                PS.Update(item);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        //// GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}
        public ActionResult Delete()
        {
            if ((PeS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PeS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            else
                return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                PS.Delete(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ErroreRole()
        {
            return View();
        }
    }
}
