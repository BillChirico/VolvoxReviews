using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Repository.Products.Movies;
using Volvox.Reviews.Repository.Reviews;
using Volvox.Reviews.Service.Products.Movies;
using Volvox.Reviews.Web.Contexts;

namespace Volvox.Reviews.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

            _movieService = new MovieService(new MovieRepository(_context));
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(_movieService.GetAll());
        }

        // GET: Movies/5
        [Route("Movies/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = _movieService.GetById((int)id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Create(movie);

                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = _movieService.GetById((int) id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.Update(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = _movieService.GetById((int)id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = _movieService.GetById((int)id);
            _movieService.Delete(movie);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
