using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface IRecordService
    {
        Task<Record> GetByIdAsync(int id);
        Task<IEnumerable<Record>> GetAllAsync();
        Task CreateAsync(Record record);
        Task UpdateAsync(Record record);
        Record IsExists(int masseurId, DateTime date);
        Record Get(Func<Record, bool> predicate);
        IEnumerable<Record> GetWithInclude();
        Task DeleteAsync(int id);
        public IEnumerable<Record> GetRange(int skipPos = 0, int count = 3);
        Task<int> GetCountAsync();
        IEnumerable<Record> AdvancedSearch(string masseurName, DateTime minDate, DateTime maxDate);
    }
}
