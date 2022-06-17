using System;
using DataModel;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataModel.Models.DTOs.Notify;

namespace Infrastructure.Validators
{
    public class NotifyHeaderValidator : AbstractValidator<NotifyHeaderForCreationDto>
    {
        private readonly MMSDbContext _repositoryContext;
        public NotifyHeaderValidator(MMSDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

              RuleFor(p => p.itemDescription)
             .NotEmpty().WithMessage("{PropertyDescription} is required.")
             .NotNull()
             .MaximumLength(10).WithMessage("{PropertyDescription} must not exceed 10 characters.");


            RuleFor(p => p.attachments)
             .NotEmpty().WithMessage("{PropertyDescription} is required.")
             .NotNull()
             .Length(0, 20).WithMessage("{PropertyDescription} must not exceed 20 characters.");
        }
    }
}
