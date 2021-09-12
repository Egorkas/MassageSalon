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
        public DateTime TimeRecord { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }

        //public string Date { get; set; }
        //public string Time { get; set; }
        //public DateTime GetStartDateTime()
        //{
        //    return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        //}
    }
}

