using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Masseur : Employee
    {
        public List<Review> Reviews { get; set; }
    }
}
