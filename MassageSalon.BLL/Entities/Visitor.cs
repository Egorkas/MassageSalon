using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Entities
{
    public class Visitor : Employee
    {
        public int MasseurId { get; set; }
        public Masseur Masseur { get; set; }
    }
}
