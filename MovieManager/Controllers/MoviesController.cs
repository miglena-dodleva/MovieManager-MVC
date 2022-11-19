using Microsoft.AspNetCore.Mvc;
using MovieManager.Data;
using MovieManager.Entities;
using MovieManager.ViewModels.Movies;
using MovieManager.ViewModels.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieManagerDbContext context;
        public MoviesController(MovieManagerDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexVM model)
        {
            model.Genres = this.context.Genres.ToList();
            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 3
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Movies.Count() / (double)model.Pager.ItemsPerPage);

            model.Movies = context.Movies
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(3)
                                     .ToList();

            return this.View(model);
        }

        public IActionResult All(IndexVM model)
        {

            model.Genres = this.context.Genres.ToList();

            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 1
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Movies.Count() / (double)model.Pager.ItemsPerPage);

            model.Movies = context.Movies
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(1)
                                     .ToList();

            return this.View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateVM()
            {
                Genres = this.context.Genres.ToList()
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Movie()
            {
                Title = model.Title,
                Summary = model.Summary,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                TrailerUrl = model.TrailerUrl,
                Country = model.Country,
                Duration = model.Duration,
                ReleaseDate = model.ReleaseDate,
                GenreId = model.GenreId,
                Genre = model.Genre
            };

            this.context.Movies.Add(item);
            this.context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Movies.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Movies");

            var model = new EditVM()
            {
                Id = item.Id,
                Title = item.Title,
                Summary = item.Summary,
                Director = item.Director,
                ImageUrl = item.ImageUrl,
                TrailerUrl= item.TrailerUrl,
                Country = item.Country,
                Duration = item.Duration,
                ReleaseDate = item.ReleaseDate,
                GenreId = item.GenreId,
                Genre = item.Genre,
                Genres = this.context.Genres.ToList()
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Movie()
            {

                Id = model.Id,
                Title = model.Title,
                Summary = model.Summary,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                TrailerUrl = model.TrailerUrl,
                Country =  model.Country,
                Duration = model.Duration,
                ReleaseDate = model.ReleaseDate,
                GenreId = model.GenreId,
                Genre = model.Genre
            };

            this.context.Movies.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Delete(int id)
        {

            var item = new Movie();
            item.Id = id;

            this.context.Movies.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
