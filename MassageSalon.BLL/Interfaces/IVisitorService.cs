using MassageSalon.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IVisitorService
    {
        void CreateVisitor(Visitor visitor);
        Visitor GetVisitorById(int? id);
        IEnumerable<Visitor> GetAll();
        void UpdateVisitor(Visitor visitor);
        void DeleteVisitor(int id);
    }
}
