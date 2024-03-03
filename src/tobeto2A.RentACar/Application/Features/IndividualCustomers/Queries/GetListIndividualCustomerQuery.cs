using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Queries;
public class GetListIndividualCustomerQuery : IRequest<GetListResponse<GetListIndividualCustomerItemDto>>
{
    public PageRequest? PageRequest;

    public class GetListIndividualCustomerQueryHandle : IRequestHandler<
        GetListIndividualCustomerQuery,GetListResponse<GetListIndividualCustomerItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualBusinessRules;

        public GetListIndividualCustomerQueryHandle(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules individualbusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualBusinessRules = individualbusinessRules;
            return;
        }

        public async Task<GetListResponse<GetListIndividualCustomerItemDto>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<IndividualCustomer>? individualCustomers = await _individualCustomerRepository.GetListAsync
                (index : request.PageRequest.PageIndex,size:request.PageRequest.PageSize);
            GetListResponse <GetListIndividualCustomerItemDto>? response = _mapper.Map<GetListResponse<GetListIndividualCustomerItemDto>>(individualCustomers);
            return (response);
        }
    }
}
