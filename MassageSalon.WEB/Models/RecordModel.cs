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
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }
        [Required]
        public DateTime TimeRecord { get; set; }
    }
}

