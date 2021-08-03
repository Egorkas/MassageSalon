using MassageSalon.DAL.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Utils
{
    public static class DbConnector
    {
        public static string GetConnectionOptions()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            //return configuration.GetConnectionString("DefaultConnection").ToString();
            return configuration.GetSection("ConnectionsString:DefaultConnection").Value;
        }
    }
}
