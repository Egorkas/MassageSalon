using MassageSalon.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;

namespace MassageSalon.WEB.Controllers
{
    public abstract class BaseController : Controller
    {
        private ILoggerService _logger;
        protected ILoggerService Logger => _logger ??= HttpContext.RequestServices.GetService<ILoggerService>();
    }
}
