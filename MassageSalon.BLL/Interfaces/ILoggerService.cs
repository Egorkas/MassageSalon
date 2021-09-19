using MassageSalon.DAL.Common.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Interfaces
{
    public interface ILoggerService : ILogger
    {
        IEnumerable<Log> GetAllLogs();
        //void Create(Log log);
    }
}
