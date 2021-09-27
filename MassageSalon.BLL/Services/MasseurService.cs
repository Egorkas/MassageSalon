using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class MasseurService : IMasseurService
    {
        private readonly IGenericRepository<Masseur> _repository;

        public MasseurService(IGenericRepository<Masseur> repository)
        {
            _repository = repository;
        }

        public void Create(Masseur masseur) =>
            _repository.Create(masseur);

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Masseur Get(Func<Masseur, bool> predicate)
        {
            return _repository.Find(predicate).FirstOrDefault();
        }

        public IEnumerable<Masseur> GetWithInclude() => _repository.GetWithInclude(x => x.Reviews);
        public IEnumerable<Masseur> GetAll() =>
            _repository.GetAll();

        public Masseur GetById(int id) =>
            _repository.Get(id);

        public void Update(Masseur masseur) =>
            _repository.Update(masseur);
    }
}
