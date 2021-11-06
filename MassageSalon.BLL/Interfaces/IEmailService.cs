using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.EmailSender
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string recipientEmail, string subject, string name, string date);
    }
}
