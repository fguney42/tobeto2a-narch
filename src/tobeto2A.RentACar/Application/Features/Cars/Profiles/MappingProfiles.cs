using Application.Features.Brands.Commands.Create;
using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCarCommand,Car>().ReverseMap();
        CreateMap<CreatedCarResponse,Car>().ReverseMap();
        CreateMap<GetListResponse<GetListCarItemDto>, IPaginate<Car>>().ReverseMap();
        CreateMap<GetListCarItemDto, Car>().ReverseMap ();
        return;
    }
}
