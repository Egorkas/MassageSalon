using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface IMasseurService
    {
        Task CreateAsync(Masseur Masseur);
        Task<Masseur> GetByIdAsync(int id);
        Task<IEnumerable<Masseur>> GetAllAsync();
        IEnumerable<Masseur> GetWithInclude();
        Task UpdateAsync(Masseur Masseur);
        Task DeleteAsync(int id);
        Masseur Get(Func<Masseur, bool> predicate);
    }
}
