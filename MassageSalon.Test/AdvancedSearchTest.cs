using MassageSalon.BLL.Extensions;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using MassageSalon.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MassageSalon.Test
{
    public class AdvancedSearchTest
    {
        [TestCase("massage",null, 0, ExpectedResult = 4 )]
        [TestCase(null,"shoulder", 0, ExpectedResult = 1 )]
        [TestCase(null, null, 43, ExpectedResult = 1)]
        [TestCase("Foot",null, 0, ExpectedResult = 1 )]
        public async Task<int> Search_Result(string title, string description, int price)
        {
            //Arrange
            var search = new Offer 
            {
                Title = title,
                Description = description,
                Price = price
            };

            Func<Offer, bool> predicate = (s => (
            (search.Title == null || s.Title.Contains(search.Title)) &&
            (search.Description == null || s.Description.Contains(search.Description) &&
            (search.Price == 0 || s.Price.Equals(search.Price))
            )));

            var mock = new Mock<IGenericRepository<Offer>>();
            mock.Setup(s =>s.Find(It.IsAny<Func<Offer, bool>>())).Returns((GetOffers()).Where(predicate).ToList());

            IOfferService _offerService = new OfferService(mock.Object);

            //Act
            var actual = _offerService.AdvancedSearch(search);

            //Assert
            //Assert.AreEqual(1, actual.Count());   
            return actual.Count();
        }

        private IEnumerable<Offer> GetOffers()
        {
            var offers = new List<Offer>
            {
                new Offer { Id = 1, Title = "Classic massage", Description = "Full body", Price = 40},
                new Offer { Id = 2, Title = "Hot stone massage", Description = "Back and shoulder", Price = 55},
                new Offer { Id = 3, Title = "Indian head massage", Description = "Head and face massage", Price = 43},
                new Offer { Id = 4, Title = "Foot/reflexology massage", Description = "Foot and legs", Price = 25}
            };

            return offers;
        }
    }
}