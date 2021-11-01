using MassageSalon.BLL.Extensions;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Services
{
    public class OfferService : IOfferService
    {
        private readonly IGenericRepository<Offer> _repository;
        public OfferService(IGenericRepository<Offer> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Offer> AdvancedSearch(Offer srchOffer)
        {
            Func<Offer, bool> predicate = (s => (
            (srchOffer.Title == null || s.Title.Contains(srchOffer.Title)) &&
            (srchOffer.Description == null || s.Description.Contains(srchOffer.Description) &&
            (srchOffer.Price == 0 || ((srchOffer.Price + 5) >= s.Price && (srchOffer.Price - 5) <= s.Price ))
            )));

            return _repository.Find(predicate);
        }

        public async Task CreateAsync(Offer offer) => await _repository.CreateAsync(offer);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public Offer Get(Func<Offer, bool> predicate) => _repository.Find(predicate).FirstOrDefault();

        public async Task<IEnumerable<Offer>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Offer> GetByIdAsync(int id) => await _repository.GetAsync(id);

        public IEnumerable<Offer> Search(string search)
        {
            return _repository.Find(s =>
                s.Title.Contains(search.NormalizedSearchString(), StringComparison.OrdinalIgnoreCase) ||
                s.Description.Contains(search.NormalizedSearchString(), StringComparison.OrdinalIgnoreCase) ||
                s.Price.ToString().Contains(search.NormalizedSearchString(), StringComparison.OrdinalIgnoreCase));
        }
        public async Task UpdateAsync(Offer offer) => await _repository.UpdateAsync(offer);
    }
}
