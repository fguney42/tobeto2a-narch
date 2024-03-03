using Application.Features.Customers.Rules;
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

namespace Application.Features.Customers.Queries;
public class GetListCorporateCustomerQuery : IRequest<GetListResponse<GetListCorporateCustomerItemDto>>
{
    public PageRequest? PageRequest;
    public class GetListCorporateCustomerQueryHandle : IRequestHandler<GetListCorporateCustomerQuery, GetListResponse<GetListCorporateCustomerItemDto>>
    {
        private  readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCorporateCustomerQueryHandle(CorporateCustomerBusinessRules corporateCustomerBusinessRules, ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
        {
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            return;
        }

        public async Task<GetListResponse<GetListCorporateCustomerItemDto>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CorporateCustomer> corporateCustomers
                = await _corporateCustomerRepository.GetListAsync(size : request.PageRequest.PageSize,index : request.PageRequest.PageIndex);
            GetListResponse<GetListCorporateCustomerItemDto> response = _mapper.Map<GetListResponse<GetListCorporateCustomerItemDto>>(corporateCustomers);
            return (response);
        }
    }
}
