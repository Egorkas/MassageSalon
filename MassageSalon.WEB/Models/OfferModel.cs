using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class OfferModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "The Length of the title can't be more than 30 symbols")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
