using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime TimeRecord { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }
        
    }
}
