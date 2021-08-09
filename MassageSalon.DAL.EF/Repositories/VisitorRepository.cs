using MassageSalon.BLL.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.DAL.EF.Repositories
{
    public class VisitorRepository : IGenericRepository<Visitor>
    {
        private MassageSalonContext _context;

        public VisitorRepository(MassageSalonContext context)
        {
            _context = context;
        }

        public void Create(Visitor item)
        {
            _context.Visitors.Add(item);
        }

        public void Delete(int id)
        {
            Visitor person = _context.Visitors.Find(id);
            if (person != null)
                _context.Visitors.Remove(person);
        }

        public IEnumerable<Visitor> Find(Func<Visitor, bool> predicate)
        {
            return _context.Visitors.Where(predicate).ToList();
        }

        public Visitor Get(int? id)
        {
            return _context.Visitors.Find(id);
        }

        public IEnumerable<Visitor> GetAll()
        {
            return _context.Visitors.ToList();
        }

        public void Update(Visitor item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
