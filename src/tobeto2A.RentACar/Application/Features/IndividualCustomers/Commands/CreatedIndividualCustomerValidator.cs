using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands;
public class CreatedIndividualCustomerValidator : AbstractValidator<CreateIndividualCustomerCommand>
{
    public CreatedIndividualCustomerValidator()
    {
        RuleFor(cic=>cic.Email).NotEmpty().NotNull(); // input alakalı //
        RuleFor(cic=>cic.NationalIdentity).NotEmpty().NotNull();
        RuleFor(cic=>cic.Password).NotEmpty().NotNull();
        RuleFor(cic=>cic.FirstName).NotEmpty().NotNull();
        RuleFor(cic => cic.LastName).NotEmpty().NotNull();
        return;
    }
}
