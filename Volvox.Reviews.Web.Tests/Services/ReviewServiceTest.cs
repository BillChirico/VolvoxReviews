using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Volvox.Reviews.Domain.Models.Reviews;
using Volvox.Reviews.Repository.Reviews;
using Volvox.Reviews.Service.Reviews;

namespace Volvox.Reviews.Web.Tests.Services
{
    [TestClass]
    public class ReviewServiceTest
    {
        private Mock<IReviewRepository> _mockRepository;
        private List<Review> _reviewList;

        [TestInitialize]
        public void TestInitializer()
        {
            _mockRepository = new Mock<IReviewRepository>();

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
                }
            };
        }

        [TestMethod]
        public void ReviewServiceTest_GetUsersReviews_ReturnsTwo()
        {
            // Arange
            var reviewService = new ReviewService(_mockRepository.Object);

            _mockRepository.Setup(reviewRepository => reviewRepository.FindBy(It.IsAny<Expression<Func<Review, bool>>>()))
                .Returns(_reviewList.Take(2));

            // Act
            var userReviews = reviewService.GetUsersReviews("TestID").ToList();

            // Assert
            Assert.IsNotNull(userReviews);
            Assert.AreEqual(2, userReviews.Count());
            Assert.AreEqual(1, userReviews[0].Id);
            Assert.AreEqual(2, userReviews[1].Id);
        }

        [TestMethod]
        public void ReviewServiceTest_GetByID()
        {
            // Arange
            var reviewService = new ReviewService(_mockRepository.Object);

            _mockRepository.Setup(reviewRepository => reviewRepository.GetById(It.IsAny<int>()))
                .Returns(_reviewList[0]);

            // Act
            var review = reviewService.GetById(1);

            // Assert
            Assert.IsNotNull(review);
        }

        [TestMethod]
        public void ReviewServiceTest_GetAll()
        {
            // Arange
            var reviewService = new ReviewService(_mockRepository.Object);

            _mockRepository.Setup(reviewRepository => reviewRepository.GetAll())
                .Returns(_reviewList);

            // Act
            var reviews = reviewService.GetAll();

            // Assert
            Assert.IsNotNull(reviews);
            Assert.AreEqual(2, reviews.Count());
        }
    }
}
