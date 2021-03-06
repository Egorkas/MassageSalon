using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Masseur : Employee
    {
        public  string TitleImagePath { get; set; }
        public string Description { get; set; }
        public IEnumerable<Record> Records{ get; set; }
        public IEnumerable<Review> Reviews{ get; set; }
    }
}
