using FluentValidation;
using MassageSalon.DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MassageSalon.WEB.Validators
{
    public class RecordIsBusyValidator : AbstractValidator<Record>
    {
        public RecordIsBusyValidator()
        {
            RuleFor(c => c.TimeRecord).NotEmpty().Must(NotLessThanNow).WithMessage("Please record to future date");
        }
        private bool NotLessThanNow(DateTime date) => date > DateTime.Now;
    }
}
