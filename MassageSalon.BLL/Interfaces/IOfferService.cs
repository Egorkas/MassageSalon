using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IOfferService
    {
        Offer GetById(int id);
        IEnumerable<Offer> GetAll();
        Offer Get(Func<Offer, bool> predicate);
        IEnumerable<Offer> Search(string search);
        void Update(Offer offer);
        void Create(Offer offer);
        void Delete(int id);
    }
}
