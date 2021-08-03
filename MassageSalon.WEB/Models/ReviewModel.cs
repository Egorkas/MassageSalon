using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string UserReview { get; set; }
        public int MasseurId { get; set; }
        public MasseurModel Masseur { get; set; }
    }
}
