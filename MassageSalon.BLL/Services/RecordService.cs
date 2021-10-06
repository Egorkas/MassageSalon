using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class RecordService : IRecordService
    {
        private readonly IGenericRepository<Record> _repository;
        public RecordService(IGenericRepository<Record> repository)
        {
            _repository = repository;
        }
        public void Create(Record record)
        {
            _repository.Create(record);
        }

        public Record Get(Func<Record, bool> predicate) => _repository.Find(predicate).FirstOrDefault();
        public IEnumerable<Record> GetWithInclude() =>
            _repository.GetWithInclude(m => m.Masseur, v => v.Visitor, o => o.Offer);
        public IEnumerable<Record> GetAll() => _repository.GetAll();

        public Record GetById(int id) => _repository.Get(id);

        public Record IsExists(int masseurId, DateTime date) => _repository.Find(x => x.MasseurId == masseurId && (x.TimeRecord.Ticks >= date.Ticks && date.AddHours(1).Ticks >= x.TimeRecord.Ticks)).FirstOrDefault();

        public void Update(Record record) => _repository.Update(record);

    }
}
