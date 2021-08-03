using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IMasseurService
    {
        void CreateMasseur(Masseur Masseur);
        Masseur GetMasseurById(int? id);
        IEnumerable<Masseur> GetAll();
        void UpdateMasseur(Masseur Masseur);
    }
}
