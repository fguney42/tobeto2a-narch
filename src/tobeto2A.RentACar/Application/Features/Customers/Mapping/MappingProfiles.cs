using Application.Features.Brands.Queries;
using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Mapping;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer,CreateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CreatedCorporateCustomerResponse,CorporateCustomer>().ReverseMap();
        CreateMap<GetListResponse<GetListCorporateCustomerItemDto>, IPaginate<CorporateCustomer>>().ReverseMap();
        CreateMap<CorporateCustomer,GetListCorporateCustomerItemDto>();
        return;
    }
}
