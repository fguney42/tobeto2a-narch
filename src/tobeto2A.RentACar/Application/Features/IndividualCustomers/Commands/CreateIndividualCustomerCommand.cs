using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands;
public class CreateIndividualCustomerCommand :IRequest<CreatedIndividualCustomerResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { set; get; }
    public string? Password { set; get; }
    public string? NationalIdentity { get; set; }
    public class CreateIndividualCustomerCommandHandle : IRequestHandler<CreateIndividualCustomerCommand,CreatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
        private readonly IMapper _mapper;

        public CreateIndividualCustomerCommandHandle(IIndividualCustomerRepository individualCustomer, IndividualCustomerBusinessRules individualCustomerBusinessRules, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomer;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
            _mapper = mapper;
            return;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
           await _individualCustomerBusinessRules.CheckIfNationalIdentityNotExists(request.NationalIdentity);
            await _individualCustomerBusinessRules.CheckIfEmailNotExits(request.Email);
            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request);
            IndividualCustomer addedIndividualCustomer = _individualCustomerRepository.Add(individualCustomer);
            CreatedIndividualCustomerResponse response = _mapper.Map<CreatedIndividualCustomerResponse>(addedIndividualCustomer);
            return (response);
        }
    }
}
