using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            var recentReviews = _reviewService.GetRecentReviews(3);

            return View(recentReviews);
        }

        public ActionResult About()
        {
            var product = _context.Reviews.FirstOrDefault(r => r.Id == 1)?.Product;

            ViewBag.Message = "Your application description page.";

            return View(product);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}