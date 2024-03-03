using Application.Features.Customers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Rules;
public class CorporateCustomerBusinessRules : BaseBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    public CorporateCustomerBusinessRules(ICorporateCustomerRepository customerRepository)
    {
        _corporateCustomerRepository = customerRepository;
    }
    public async Task CheckIfTaxNoNotExists(string taxNo)
    {
        bool isExists =   this._corporateCustomerRepository.Get
            (ccr=>ccr.TaxNo.Equals(taxNo)) is not  null;
        if (isExists)
            throw new BusinessException
                (CorporateCustomerMessages.CorporateCustomerTaxNoAlreadyExists);
        return;
    }
    public async Task CheckIfEmailNotExists(string email)
    {
        bool isExists = this._corporateCustomerRepository.Get
          (ccr => ccr.Email.Equals(email)) is not null;
        if (isExists)
            throw new BusinessException(CorporateCustomerMessages.CorporateCustomerMailAlreadyExists);
        return;
    }
}
