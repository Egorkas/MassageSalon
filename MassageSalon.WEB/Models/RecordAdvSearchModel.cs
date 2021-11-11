using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models
{
    public class RecordAdvSearchModel
    {
        public string MasseurName { get; set; }
        public DateTime MinDate { get; set; } = default;
        public DateTime MaxDate { get; set; } = default;
    }
}
