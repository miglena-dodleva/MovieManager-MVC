using Microsoft.AspNetCore.Mvc;
using MovieManager.Data;
using MovieManager.Entities;
using MovieManager.ViewModels.Genres;
using MovieManager.ViewModels.Pager;
using System;
using System.Linq;

namespace MovieManager.Controllers
{
    public class GenresController : Controller
    {
        private readonly MovieManagerDbContext context;
        public GenresController(MovieManagerDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index(IndexVM model)
        {

            model.Pager = model.Pager ?? new PagerVM();

            model.Pager.Page = model.Pager.Page <= 0
                                       ? 1
                                       : model.Pager.Page;

            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                        ? 3
                                        : model.Pager.ItemsPerPage;

            model.Pager.PagesCount = (int)Math.Ceiling(context.Genres.Count() / (double)model.Pager.ItemsPerPage);

            model.Genres = context.Genres
                                     .OrderBy(i => i.Id)
                                     .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                     .Take(3)
                                     .ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var item = new Genre()
            {
                Name = model.Name
            };

            this.context.Genres.Add(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        public IActionResult Edit(int id)
        {

            var item = this.context.Genres.Where(x => x.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Genres");

            var model = new EditVM()
            {
                Id = item.Id,
                Name = item.Name
            };

            return this.View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return this.View(model);

            var item = new Genre()
            {

                Id = model.Id,
                Name = model.Name
            };

            this.context.Genres.Update(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }

        public IActionResult Delete(int id)
        {

            var item = new Genre();
            item.Id = id;

            this.context.Genres.Remove(item);
            this.context.SaveChanges();

            return RedirectToAction("Index", "Genres");
        }
    }
}
