using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface IReviewService
    {
        Task CreateAsync(Review Review);
        Task<Review> GetByIdAsync(int id);
        IEnumerable<Review> GetAll();
        Task UpdateAsync(Review Review);
    }
}
