using FluentValidation;
using Resturants.Application.Dishs.Commands.CreateDish;

namespace Resturants.Application.Resturants.Command
{
    public class CreateDishCommandValidator :  AbstractValidator<CreateDishCommand>    {


        public CreateDishCommandValidator()
        {
            RuleFor(dto => dto.KiloCalories)
                .GreaterThanOrEqualTo(0).WithMessage("killo caloris value must be gereater than or equal 0");

            RuleFor(dto => dto.Price)
               .GreaterThanOrEqualTo(0).WithMessage("price value must be gereater than or equal 0");

        }



    }
}
