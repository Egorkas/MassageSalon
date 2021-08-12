using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class VisitorModel : EmployeeModel
    {
        public int MasseurId { get; set; }
        public MasseurModel Masseur { get; set; }
    }
}
