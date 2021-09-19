using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IReviewService
    {
        void Create(Review Review);
        Review GetById(int id);
        IEnumerable<Review> GetAll();
        void Update(Review Review);
    }
}
