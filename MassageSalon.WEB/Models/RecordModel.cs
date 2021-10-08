using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class RecordModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime TimeRecord { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int VisitorId { get; set; }
        public VisitorModel Visitor { get; set; }
        public int MasseurId { get; set; }
        public MasseurModel Masseur { get; set; }
        public int OfferId { get; set; }
        public OfferModel Offer { get; set; }
     }
}

