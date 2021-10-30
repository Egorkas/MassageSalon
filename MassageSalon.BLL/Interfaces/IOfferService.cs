using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface IOfferService
    {
        Task<Offer> GetByIdAsync(int id);
        Task<IEnumerable<Offer>> GetAllAsync();
        Offer Get(Func<Offer, bool> predicate);
        IEnumerable<Offer> Search(string search);
        Task UpdateAsync(Offer offer);
        Task CreateAsync(Offer offer);
        Task DeleteAsync(int id);
    }
}
