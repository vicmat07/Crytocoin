using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class CreateUserValidator : AbstractValidator<User>
    {
        
        public CreateUserValidator()
        {
           
            RuleFor(obj => obj.FirstName)
                .MinimumLength(3).WithMessage("Must have at least 3 characters");
            RuleFor(obj => obj.LastName)
                .MinimumLength(3).WithMessage("Must have at least 3 characters");
            RuleFor(obj => obj.Age).GreaterThan(18);
            RuleFor(obj => obj.Address).NotNull();
            RuleFor(obj => obj.Email)
                .NotNull().WithMessage("Email is required")
                .EmailAddress().WithMessage("Enter a valid email");


        }
    }
}
