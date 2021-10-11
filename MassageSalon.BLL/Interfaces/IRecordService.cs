using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IRecordService
    {
        Record GetById(int id);
        IEnumerable<Record> GetAll();
        void Create(Record record);
        void Update(Record record);
        Record IsExists(int masseurId, DateTime date);
        Record Get(Func<Record, bool> predicate);
        IEnumerable<Record> GetWithInclude();
    }
}
