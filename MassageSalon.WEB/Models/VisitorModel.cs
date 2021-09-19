using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class VisitorModel : EmployeeModel
    {
        
        [Phone]
        public string PhoneNumber { get; set; }
        [StringLength(20, ErrorMessage ="Login must be shorter than 20 symbols")]
        public string Login { get; set; }
        public string Password { get; set; }


        public int? RoleId { get; set; } = 2;
        public RoleModel Role { get; set; }

        public IEnumerable<RecordModel> RecordModels { get; set; }
    }
}
