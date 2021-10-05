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
        [Required(ErrorMessage ="Enter your comment")]
        [Display(Name = "rewiew")]
        [MaxLength(100,ErrorMessage ="Max Length equal 100 symbols.")]
        public string UserReview { get; set; }
        public int VisitorId { get; set; }
        public VisitorModel Visitor { get; set; }
        [Required]
        public int MasseurId { get; set; }
        public MasseurModel Masseur { get; set; }
        
    }
}
