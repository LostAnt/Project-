using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DomainShop;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MvcShop.Models;
using RepositoryShop.Contexts;
using System.Web.Security;
using ServicesShop.Service;
using ServicesShop.Interfaces;
using AutoMapper;
using System.Security.Policy;

namespace MvcShop.Controllers
{
    public class AccountController : Controller
    {
        IPersonService ps;
        IHash Hash0;
        public AccountController(IPersonService ps,IHash hash)
        {
            this.ps = ps;
            this.Hash0 = hash;
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(new Login { Name = User.Identity.Name });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
           {
                // поиск пользователя в бд
                Person user = null;
                {
               string s = model.Name;            
                    user = ps.GetItem(model.Name);
                if ((user != null) && (Hash0.GetHashString(model.Password) == user.Password));
                else user = null;

                }
                if (user != null)
                {                    
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
           }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Person user = new Person();
                    user = null;
                    {
                        user = ps.GetItem(model.Email);
                        if (user == null) user = ps.GetItem(model.Login);
                    }
                    if (user == null)
                    {
                        // создаем нового пользователя                   
                        Person PE = new Person();
                        PE.Password =Hash0.GetHashString(model.Password);
                        PE.Login = model.Login;
                        PE.FirstName = model.FirstName;
                        PE.LastName = model.LastName;
                        PE.Email = model.Email;
                        PE.Birthdate = model.Birthdate;
                        PE.RegistrationDate = DateTime.Now;
                        PE.Role = "user";
                        ps.Create(PE);
                        user = PE;
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Login, true);
                            return RedirectToAction("Home", "Home");
                        }
                    }
                    // если пользователь удачно добавлен в бд

                    else
                    {
                        ModelState.AddModelError("", "Пользователь с таким Email или логином уже существует");
                    }

                    return View(model);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View(model);
            }
            return View(model);
        }


        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}