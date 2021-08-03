using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _repository;

        public ReviewService(IGenericRepository<Review> repository)
        {
            _repository = repository;
        }

        public void CreateReview(Review review) =>
            _repository.Create(review);

        public IEnumerable<Review> GetAll() =>
            _repository.GetAll();

        public Review GetReviewById(int? id) =>
            _repository.Get(id);

        public void UpdateReview(Review review) =>
            _repository.Update(review);
    }
}
