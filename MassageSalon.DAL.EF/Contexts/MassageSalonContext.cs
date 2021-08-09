using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MassageSalon.BLL.Entities;
using MassageSalon.DAL.Common.Entities;

namespace MassageSalon.DAL.EF.Contexts
{
    public class MassageSalonContext : DbContext
    {
        public DbSet<Masseur> Masseurs { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public MassageSalonContext()
        {

        }
        public MassageSalonContext(DbContextOptions<MassageSalonContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
