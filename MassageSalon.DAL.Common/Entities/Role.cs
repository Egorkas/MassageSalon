using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = "user";
        public List<Visitor> Users { get; set; }
        public Role()
        {
            Users = new List<Visitor>();
        }
    }
}
