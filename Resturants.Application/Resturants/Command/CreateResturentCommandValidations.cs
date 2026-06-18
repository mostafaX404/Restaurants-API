using FluentValidation;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Resturants.Command
{
    public class CreateResturentCommandValidations :  AbstractValidator<CreateResturantCommand>    {

        private readonly List<string> categoriesList = ["Jaban", "Egypt", "US", "KSA", "UK"];

        public CreateResturentCommandValidations()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Category).Must(categoriesList.Contains)
                .WithMessage("Invalid Category");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(dto => dto.Category)
                .NotEmpty().WithMessage("Insert a valid category");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide a valid email address");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("Please provide a valid postal code (XX-XXX).");
        }


    }
}
