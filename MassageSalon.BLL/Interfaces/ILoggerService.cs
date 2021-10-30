using MassageSalon.DAL.Common.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Interfaces
{
    public interface ILoggerService : ILogger
    {
        Task<IEnumerable<Log>> GetAllLogsAsync();
    }
}
