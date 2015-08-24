using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Volvox.Reviews.Domain.Models.Products.Movies;
using Volvox.Reviews.Domain.Models.Products.Television;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Reviews;
using Volvox.Reviews.Service.Reviews;
using Volvox.Reviews.Web.Contexts;

namespace Volvox.Reviews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            var context = new ApplicationDbContext();

            _reviewService = new ReviewService(new ReviewRepository(context));
            _context = context;
        }

        public ActionResult Index()
        {
            var recent = _reviewService.GetRecentReviews(5);

            return View(recent);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            /*var firstOrDefault = _context.Movies.FirstOrDefault(m => m.Id == 1);
            if (firstOrDefault != null)
                _reviewService.Create(new Review()
                {
                    Title = "Test Review",
                    Body = "This is a test review.",
                    Rating = 8.7,
                    Product = firstOrDefault,
                    ProductId = firstOrDefault.Id
                });*/

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}