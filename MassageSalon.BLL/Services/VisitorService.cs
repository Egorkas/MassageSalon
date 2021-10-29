using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IGenericRepository<Visitor> _repository;

        public VisitorService(IGenericRepository<Visitor> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Visitor visitor) =>
            await _repository.CreateAsync(visitor);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public Visitor Get(Func<Visitor, bool> predicate) => _repository.Find(predicate).FirstOrDefault();

        public async Task<IEnumerable<Visitor>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Visitor> GetByIdAsync(int id) =>
            await _repository.GetAsync(id);

        public Visitor GetWithInclude()
        {
            return _repository.GetWithInclude(u => u.Role).FirstOrDefault();
        }

        public Visitor GetWithInclude(int id)
        {
            var visitors = _repository.GetWithInclude(u => u.Role);
            return visitors.FirstOrDefault(user => user.Id == id);
        }

        public async Task UpdateAsync(Visitor visitor) =>
            await _repository.UpdateAsync(visitor);
    }
}
