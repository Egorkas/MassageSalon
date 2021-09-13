using FluentValidation;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Validators
{
    public class RecordValidator : AbstractValidator<Record>
    {
        private  RecordService recordService;
        public RecordValidator()
        {
            RuleFor(c => c.TimeRecord).NotEmpty().Must(timeRecord => ).WithMessage("Please record to future date");
        }
        private bool NotLessThanNow(DateTime date) => date > DateTime.Now;

        RuleFor(x => x.Id)
    .Must(id =>
    {
            using (var db = HostContext.AppHost.GetDbConnection(base.Request))
            {
                return !db.Exists<EntityName>(x => x.Id == id);
            }
        })
    .WithErrorCode("AlreadyExists")
    .WithMessage("...");
    }
}
