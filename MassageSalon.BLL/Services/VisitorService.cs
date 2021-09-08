using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class VisitorService : IVisitorService
    {
        private readonly IGenericRepository<Visitor> _repository;

        public VisitorService(IGenericRepository<Visitor> repository)
        {
            _repository = repository;
        }

        public void Create(Visitor visitor) =>
            _repository.Create(visitor);

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Visitor Get(Func<Visitor, bool> predicate)
        {
            return _repository.Find(predicate).FirstOrDefault();
        }

        public IEnumerable<Visitor> GetAll() =>
            _repository.GetAll();

        public Visitor GetById(int id) =>
            _repository.Get(id);

        public void Update(Visitor visitor) =>
            _repository.Update(visitor);
    }
}
