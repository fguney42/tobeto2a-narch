using Application.Features.IndividualCustomers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Rules;
public class IndividualCustomerBusinessRules : BaseBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
        return;
    }
    public async Task  CheckIfNationalIdentityNotExists(string nationalIdentity)
    {
        bool isExits = _individualCustomerRepository.Get(icr=>icr.NationalIdentity.Equals(nationalIdentity)) is not null;
        if (isExits)
            throw new BusinessException(IndividualCustomerMessages.NationalIdentityIsExits);
        return;
    }
    public async Task CheckIfEmailNotExits(string email)
    {

        bool isExits = _individualCustomerRepository.Get(icr => icr.Email.Equals(email)) is not null;
        if (isExits)
            throw new BusinessException(IndividualCustomerMessages.NationalIdentityIsExits);
        return;
    }
}
