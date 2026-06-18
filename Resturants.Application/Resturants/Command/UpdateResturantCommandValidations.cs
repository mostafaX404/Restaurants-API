using FluentValidation;
using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
