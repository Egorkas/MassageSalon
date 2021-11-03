using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Models.PageModel
{
    public class ViewPageModel<Entity> where Entity : class
    {
        public IEnumerable<Entity> Users { get; set; }
        public PageModel PageModel { get; set; }
    }
}
