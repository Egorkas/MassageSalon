using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class OfferService : IOfferService
    {
        private readonly IGenericRepository<Offer> _repository;
        public OfferService(IGenericRepository<Offer> repository)
        {
            _repository = repository;
        }
        public void Create(Offer offer) => _repository.Create(offer);

        public void Delete(int id) => _repository.Delete(id);

        public Offer Get(Func<Offer, bool> predicate) => _repository.Find(predicate).FirstOrDefault();

        public IEnumerable<Offer> GetAll() => _repository.GetAll();

        public Offer GetById(int id) => _repository.Get(id);

        public void Update(Offer offer) => _repository.Update(offer);
    }
}
