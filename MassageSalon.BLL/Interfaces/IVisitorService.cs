using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface IVisitorService
    {
        Task CreateAsync(Visitor visitor);
        Task<Visitor> GetByIdAsync(int id);
        Task<IEnumerable<Visitor>> GetAllAsync();
        Task UpdateAsync(Visitor visitor);
        Task DeleteAsync(int id);
        Visitor Get(Func<Visitor, bool> predicate);
        Visitor GetWithInclude();
        Visitor GetWithInclude(int id);
    }
}
