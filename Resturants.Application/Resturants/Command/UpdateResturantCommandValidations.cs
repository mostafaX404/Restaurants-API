using FluentValidation;

namespace Resturants.Application.Resturants.Command
{
    public class UpdateResturantCommandValidations :  AbstractValidator<UpdateResturantCommand>    {


        public UpdateResturantCommandValidations()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

        }


    }
}
