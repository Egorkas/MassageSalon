using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IVisitorService
    {
        void Create(Visitor visitor);
        Visitor GetById(int id);
        IEnumerable<Visitor> GetAll();
        void Update(Visitor visitor);
        void Delete(int id);
    }
}
