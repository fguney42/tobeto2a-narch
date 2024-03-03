using Application.Features.Cars.Commands.Create;
using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create;
public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { set; get; }
    public string? Password { set; get; }
    public string? TaxNo { set; get; }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
    {
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper,
            CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            return ;
        }

        public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _corporateCustomerBusinessRules.CheckIfTaxNoNotExists(request.TaxNo);
            await _corporateCustomerBusinessRules.CheckIfEmailNotExists(request.Email);
            CorporateCustomer customer = _mapper.Map<CorporateCustomer>(request);
            CorporateCustomer addedCorporateCustomer = 
                _corporateCustomerRepository.Add(customer);
            CreatedCorporateCustomerResponse response = 
                _mapper.Map<CreatedCorporateCustomerResponse>(addedCorporateCustomer);
            return (response);
        }
    }
}
