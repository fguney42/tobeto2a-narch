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

namespace Application.Features.Brands.Queries;
public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandItemDto>>  
    // isteği işleyen sınıf olarak işaretliyoruz// GetlistResponse sayfalama yapmak için kullanılır. 
    // IRequest'ten türemeli Mediator için //
    // IRequest Handler ise İsteği işleyici olarak ayarlıyoruz yazdığımız class'ı o ise RequestHandle etmek için.
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandItemDto>> // Sayfalama //
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        // Task = asenkron ve senkron programlama için kullanılır. // await Async işlem //
        public async Task<GetListResponse<GetListBrandItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _brandRepository.GetListAsync
                (index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);
            GetListResponse<GetListBrandItemDto> response = _mapper.Map<GetListResponse<GetListBrandItemDto>>(brands);
            return response;
        }
    }
}
