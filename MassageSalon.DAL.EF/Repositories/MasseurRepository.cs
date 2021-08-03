using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassageSalon.DAL.EF.Repositories
{
    public class MasseurRepository : IGenericRepository<Masseur>
    {
        private MassageSalonContext _context;

        public MasseurRepository(MassageSalonContext context)
        {
            _context = context;
        }

        public void Create(Masseur item)
        {
            _context.Masseurs.Add(item);
        }

        public void Delete(int id)
        {
            Masseur person = _context.Masseurs.Find(id);
            if (person != null)
                _context.Masseurs.Remove(person);
        }

        public IEnumerable<Masseur> Find(Func<Masseur, bool> predicate)
        {
            return _context.Masseurs.Where(predicate).ToList();
        }

        public Masseur Get(int? id)
        {
            return _context.Masseurs.Find(id);
        }

        public IEnumerable<Masseur> GetAll()
        {
            return _context.Masseurs.ToList();
        }

        public void Update(Masseur item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
