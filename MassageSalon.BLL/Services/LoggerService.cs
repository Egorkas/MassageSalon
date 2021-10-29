using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IGenericRepository<Log> _repository;

        public LoggerService(IGenericRepository<Log> repository)
        {
            _repository = repository;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync() => await _repository.GetAllAsync();

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var log = new Log { Level = logLevel, Time = DateTime.Now, Message = formatter(state, exception) };
             await _repository.CreateAsync(log);
        }
    }
}
