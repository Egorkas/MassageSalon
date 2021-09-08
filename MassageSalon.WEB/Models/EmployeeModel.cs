using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class EmployeeModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name= "Surname")]
        public string Surname { get; set; }
        [Display(Name = "FatherName")]
        public string FatherName { get; set; }
    }
}
