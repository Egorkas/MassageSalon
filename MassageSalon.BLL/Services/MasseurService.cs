using AutoMapper;
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
    public class MasseurService : IMasseurService
    {
        private readonly IGenericRepository<Masseur> _repository;

        public MasseurService(IGenericRepository<Masseur> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Masseur masseur) => await _repository.CreateAsync(masseur);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public Masseur Get(Func<Masseur, bool> predicate)
        {
            return _repository.Find(predicate).FirstOrDefault();
        }

        public IEnumerable<Masseur> GetWithInclude() => _repository.GetWithInclude(x => x.Reviews);
        public async Task<IEnumerable<Masseur>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Masseur> GetByIdAsync(int id) => await _repository.GetAsync(id);

        public async Task UpdateAsync(Masseur masseur) => await _repository.UpdateAsync(masseur);
    }
}
