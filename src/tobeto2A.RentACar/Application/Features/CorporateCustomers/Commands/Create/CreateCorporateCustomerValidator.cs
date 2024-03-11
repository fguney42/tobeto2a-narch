using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create;
public class CreateCorporateCustomerValidator : AbstractValidator<CreateCorporateCustomerCommand>
{
    public CreateCorporateCustomerValidator()
    {
        RuleFor(ccc => ccc.Password).NotEmpty().NotNull();
        RuleFor(ccc=>ccc.Email).NotNull().NotEmpty();
        RuleFor(ccc=>ccc.TaxNo).NotNull().NotEmpty();
        return;
    }
}
