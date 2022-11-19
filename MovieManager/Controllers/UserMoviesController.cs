using Microsoft.AspNetCore.Mvc;
using MovieManager.Data;
using MovieManager.Entities;
using MovieManager.ViewModels.Pager;
using MovieManager.ViewModels.UserMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class UserMoviesController : Controller
    {
        private readonly MovieManagerDbContext context;
        public UserMoviesController(MovieManagerDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexVM model)
        {
            model.Users = this.context.Users.ToList();
            model.Movies = this.context.Movies.ToList();



            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 4
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.UserMovies.Count() / (double)model.Pager.ItemsPerPage);

            model.UserMovies = context.UserMovies
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(4)
                                     .ToList();

            return this.View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateVM()
            {
                Users = this.context.Users.ToList(),
                Movies = this.context.Movies.ToList(),
                User = new User(),
                Movie = new Movie()
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new UserMovie()
            {
                UserId = model.UserId,
                MovieId = model.MovieId,
                User = model.User,
                Movie = model.Movie
            };

            this.context.UserMovies.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "UserMovies");
        }


        public IActionResult Delete(int id)
        {

            var item = new UserMovie();
            item.Id = id;

            this.context.UserMovies.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "UserMovies");
        }
    }
}
