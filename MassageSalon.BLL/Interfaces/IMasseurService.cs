using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IMasseurService
    {
        void Create(Masseur Masseur);
        Masseur GetById(int id);
        IEnumerable<Masseur> GetAll();
        IEnumerable<Masseur> GetWithInclude();
        void Update(Masseur Masseur);
        void Delete(int id);
        Masseur Get(Func<Masseur, bool> predicate);
    }
}
