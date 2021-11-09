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
        private readonly IGenericRepository<Masseur> _repositoryMasseur;
        public RecordService(IGenericRepository<Record> repository, IGenericRepository<Masseur> repositoryMasseur)
        {
            _repository = repository;
            _repositoryMasseur = repositoryMasseur;
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

        public IEnumerable<Record> GetRange(int skipPos = 0, int count = 3) => _repository.GetRange(skipPos, count);

        public Task<int> GetCountAsync() => _repository.GetCountAsync();

        public IEnumerable<Record> AdvancedSearch(string masseurName, DateTime minDate, DateTime maxDate)
        {
            Func<Record, bool> predicate;
            if(masseurName == null)
            {
                predicate = new Func<Record, bool>((r) =>
                 (minDate == default || r.TimeRecord >= minDate) &&
                 (maxDate == default || r.TimeRecord <= maxDate)
             );
            }
            else
            {
                var masseur = _repositoryMasseur.Find(m => m.Name.Contains(masseurName)).FirstOrDefault();
                predicate = new Func<Record, bool>((r) =>
                (masseur == null || r.MasseurId == masseur.Id) &&
                (minDate == default || r.TimeRecord >= minDate) &&
                (maxDate == default || r.TimeRecord <= maxDate)
                );
            }
            

            return _repository.Find(predicate);
        }
    }
}
