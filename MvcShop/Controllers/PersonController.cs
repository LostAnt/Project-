using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainShop;
using MvcShop.Models;
using ServicesShop.Interfaces;

namespace MvcShop.Controllers
{
    public class PersonController : Controller
    {
        IPersonService PS;
        public PersonController(IPersonService ps)
         {
            PS = ps;
         }

        // GET: Person
        public ActionResult Index()
        {
            if ((!HttpContext.User.Identity.IsAuthenticated) || (PS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            return View(PS.GetItemList());
        }

        // GET: Person/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = PS.GetItem(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            if ((!HttpContext.User.Identity.IsAuthenticated) || (PS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            return View();
        }

        // POST: Person/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,FirstName,LastName,Email,Password,Birthdate,Role,RegistrationDate,Male")] Person person)
        {
            if (ModelState.IsValid)
            {
                PS.Create(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(long id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if ((!HttpContext.User.Identity.IsAuthenticated) || (PS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            Person person =PS.GetItem(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,FirstName,LastName,Email,Password,Birthdate,Role,RegistrationDate,Male")] Person person)
        {
            if (ModelState.IsValid)
            {
                PS.Update(person);
                PS.Save();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if ((!HttpContext.User.Identity.IsAuthenticated) || (PS.GetItem(HttpContext.User.Identity.Name).Role != "admin") || ((PS.GetItem(HttpContext.User.Identity.Name).Role == null))) return View("ErroreRole");
            Person person = PS.GetItem(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PS.Delete(id);
            PS.Save();
            return RedirectToAction("Index");
        }
    }
}
