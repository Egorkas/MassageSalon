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
    public class ReviewRepository : IGenericRepository<Review>
    {
        private MassageSalonContext _context;

        public ReviewRepository(MassageSalonContext context)
        {
            _context = context;
        }

        public void Create(Review item)
        {
            _context.Reviews.Add(item);
        }

        public void Delete(int id)
        {
            Review review = _context.Reviews.Find(id);
            if (review != null)
                _context.Reviews.Remove(review);
        }

        public IEnumerable<Review> Find(Func<Review, bool> predicate)
        {
            return _context.Reviews.Where(predicate).ToList();
        }

        public Review Get(int? id)
        {
            return _context.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.Include(r => r.Masseur).ToList();
        }

        public void Update(Review item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
