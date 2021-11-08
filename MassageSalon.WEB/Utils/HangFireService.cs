using MassageSalon.BLL.EmailSender;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MassageSalon.WEB.Filters;

namespace MassageSalon.WEB.Utils
{
    public class HangFireService
    {
        private  IRecordService _record;
        private  IEmailService _mail;
        public HangFireService(IRecordService record, IEmailService mail)
        {
            _record = record;
            _mail = mail;
        }
        public void Reccuring()
        {
            var records = _record.GetWithInclude().Where(r => r.TimeRecord.Hour >= DateTime.Now.AddHours(1).Hour);
            foreach (var item in records)
            {
                _mail.SendEmailAsync(item.Visitor.Login, "One hour untill your massage!!!", item.Visitor.Name, item.TimeRecord.ToString()).Wait();
            }
        }
    }
}
