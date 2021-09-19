using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace MassageSalon.DAL.Common.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }
}
