using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(i => i.CarState).NotEmpty()
        .NotNull().Equals((Int32)CarStatus.Rented);
        RuleFor(i=>i.Plate).NotEmpty().NotNull();
        RuleFor(i => i.Kilometer).GreaterThan(-1).NotNull();
        RuleFor(i=>i.BrandName).NotNull().NotEmpty(); 
        RuleFor(i => i.ModelName).NotEmpty().NotNull(); 
        RuleFor(i => i.ColorName).NotEmpty().NotNull();
        // .NotNull()//Null Reference Control && property empty control
        //  RuleFor(i=>i.Kilometer).LessThan(250000); // Example
        //  .WithMessage("");



    }
}
