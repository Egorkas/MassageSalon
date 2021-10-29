using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _repository;

        public ReviewService(IGenericRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Review review) => await _repository.CreateAsync(review);

        public IEnumerable<Review> GetAll() =>
            _repository.GetWithInclude(m => m.Masseur, v => v.Visitor);

        public async Task<Review> GetByIdAsync(int id) =>
            await _repository.GetAsync(id);

        public async Task UpdateAsync(Review review) =>
            await _repository.UpdateAsync(review);
    }
}
