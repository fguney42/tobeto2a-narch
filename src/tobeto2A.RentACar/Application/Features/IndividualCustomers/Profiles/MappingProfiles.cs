using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIndividualCustomerCommand, IndividualCustomer>().ReverseMap();
        CreateMap<CreatedIndividualCustomerResponse, IndividualCustomer>().ReverseMap();
        CreateMap<IPaginate<IndividualCustomer>, GetListResponse<GetListIndividualCustomerItemDto>>().ReverseMap() ;
        CreateMap<IndividualCustomer, GetListIndividualCustomerItemDto>().ReverseMap();
        return;
    }
}
