using Microsoft.AspNetCore.Mvc;
using MovieManager.Data;
using MovieManager.ViewModels.Pager;
using MovieManager.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieManagerDbContext context;
        public AdminController(MovieManagerDbContext context)
        {
            this.context = context;
        }
        public IActionResult AllUsers(IndexVM model)
        {

            model.UserMovies = this.context.UserMovies.ToList();

            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 4
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Users.Count() / (double)model.Pager.ItemsPerPage);

            model.Users = context.Users
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(4)
                                     .ToList();

            return this.View(model);
        }
    }
}
