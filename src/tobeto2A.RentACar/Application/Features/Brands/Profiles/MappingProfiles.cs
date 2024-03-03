using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand,CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandItemDto>>().ReverseMap();
        CreateMap<Brand, GetListBrandItemDto>().ReverseMap();
    }
}
