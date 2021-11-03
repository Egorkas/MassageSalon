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
    public class RecordService : IRecordService
    {
        private readonly IGenericRepository<Record> _repository;
        public RecordService(IGenericRepository<Record> repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(Record record) => await _repository.CreateAsync(record);
        public Record Get(Func<Record, bool> predicate) => _repository.Find(predicate).FirstOrDefault();
        public IEnumerable<Record> GetWithInclude() =>
            _repository.GetWithInclude(m => m.Masseur, v => v.Visitor, o => o.Offer);
        public async Task<IEnumerable<Record>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Record> GetByIdAsync(int id) => await _repository.GetAsync(id);

        public Record IsExists(int masseurId, DateTime date) => _repository.Find(x => x.MasseurId == masseurId && x.TimeRecord == date).FirstOrDefault();

        public async Task UpdateAsync(Record record) => await _repository.UpdateAsync(record);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    }
}
