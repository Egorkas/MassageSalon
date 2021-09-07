using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
    }
}
