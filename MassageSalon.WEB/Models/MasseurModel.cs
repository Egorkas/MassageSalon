using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class MasseurModel : EmployeeModel
    {
        public string TitleImagePath { get; set; }
        public string Description { get; set; }

        public IEnumerable<RecordModel> RecordModels { get; set; }
    }
}
