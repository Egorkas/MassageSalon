using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review Review);
        Review GetReviewById(int? id);
        IEnumerable<Review> GetAll();
        void UpdateReview(Review Review);
    }
}
