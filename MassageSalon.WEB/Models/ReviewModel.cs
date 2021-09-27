using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "rewiew")]
        public string UserReview { get; set; }
        public int VisitorId { get; set; }
        public VisitorModel Visitor { get; set; }
        [Required]
        public int MasseurId { get; set; }
        public MasseurModel Masseur { get; set; }
        
    }
}
