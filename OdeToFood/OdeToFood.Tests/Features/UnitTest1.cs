using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = BuildRestaurantAndReviews(ratings: 4);


            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(ratings: new [] {4,8});

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Weighted_Averaging_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(ratings: new[] { 3, 9 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(5, result.Rating);
        }
        private Restaurant BuildRestaurantAndReviews (params int [] ratings)
        {
            var restaurant = new Restaurant();

            restaurant.Reviews =
                ratings.Select(r => new RestaurantReview { Rating = r })
                .ToList();
            return restaurant;
        }
    }
}
