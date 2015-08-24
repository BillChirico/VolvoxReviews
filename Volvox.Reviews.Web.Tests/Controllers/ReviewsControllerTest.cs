using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Reviews;
using Volvox.Reviews.Service.Reviews;
using Volvox.Reviews.Web.Controllers;

namespace Volvox.Reviews.Web.Tests.Controllers
{
    [TestClass]
    public class ReviewsControllerTest
    {
        private Mock<IReviewService> _mockService;
        private List<Review> _reviewList;

        [TestInitialize]
        public void TestInitializer()
        {
            _mockService = new Mock<IReviewService>();

            _reviewList = new List<Review>
            {
                new Review()
                {
                    Id = 1,
                    Title = "First Review Title",
                    Body = "First Review Body",
                    Rating = 10,
                },
                new Review()
                {
                    Id = 2,
                    Title = "Second Review Title",
                    Body = "Second Review Body",
                    Rating = 5,
                },
                new Review()
                {
                    Id = 3,
                    Title = "Third Review Title",
                    Body = "Third Review Body",
                    Rating = 1,
                }
            };
        }
        
        /*[TestMethod]
        public void ReviewsControllerTest_Index()
        {
            // Arrange
            var reviewsController = new ReviewsController(_mockService.Object);

            _mockService.Setup(reviewService => reviewService.GetUsersReviews(It.IsAny<string>()))
                .Returns(_reviewList);

            // Act
            var userReviews = (((ViewResult) reviewsController.Index()).Model) as List<Review>;

            // Assert
            Assert.IsNotNull(userReviews);
        }

        [TestMethod]
        public void ReviewsControllerTest_Details()
        {
            // Arrange
            var reviewsController = new ReviewsController(_mockService.Object);

            _mockService.Setup(reviewService => reviewService.GetById(It.IsAny<int>()))
                .Returns(_reviewList[0]);

            // Act
            var review = (((ViewResult)reviewsController.Details(1)).Model) as Review;

            // Assert
            Assert.IsNotNull(review);
            Assert.AreEqual("First Review Title", review.Title);
        }*/
    }
}
