using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieManager.AuthenticationFilter;
using MovieManager.Data;
using MovieManager.Entities;
using MovieManager.Models;
using MovieManager.Sessions;
using MovieManager.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieManagerDbContext context;
        public HomeController(MovieManagerDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            var loggedUser = this.context.Users.
               Where(x => x.Username == model.Username && x.Password == model.Password)
               .FirstOrDefault();

            if (!this.ModelState.IsValid)
                return this.View(model);


            if (loggedUser == null)
                return RedirectToAction("Register", "Home");


            HttpContext.Session.SetObjectAsJson("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {

            if (this.ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = model.Password
                };

                if (!this.context.Users.Contains(user))
                {
                    this.context.Users.Add(user);
                    this.context.SaveChanges();
                    return RedirectToAction("Login", "Home");
                }
                return RedirectToAction("Login", "Home");

            }

            var registeredUser = this.context.Users.
                Where(x => x.FirstName == model.FirstName
                && x.LastName == model.LastName
                && x.Username == model.Username
                && x.Password == model.Password)
                .FirstOrDefault();

            if (registeredUser != null)
                return this.View(model);


            HttpContext.Session.SetObjectAsJson("loggedUser", registeredUser);
            if (!this.ModelState.IsValid)
                return this.View(model);


            return RedirectToAction("Index", "Home");
        }

        [Auth]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Register", "Home");
        }
    }
}
