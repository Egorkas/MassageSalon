using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string UserReview { get; set; }
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }
    }
}
