using MassageSalon.BLL.Entities;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
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

        public void CreateVisitor(Visitor visitor) =>
            _repository.Create(visitor);

        public IEnumerable<Visitor> GetAll() =>
            _repository.GetAll();

        public Visitor GetVisitorById(int? id) =>
            _repository.Get(id);

        public void UpdateVisitor(Visitor visitor) =>
            _repository.Update(visitor);
    }
}
