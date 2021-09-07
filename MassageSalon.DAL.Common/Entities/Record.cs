using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }
        public DateTime TimeRecord { get; set; }
    }
}
