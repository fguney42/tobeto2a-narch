using Application.Features.Cars.Rules;
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

namespace Application.Features.Cars.Queries;
public class GetListCarQuery : IRequest<GetListResponse<GetListCarItemDto>>
{
    public PageRequest? PageRequest;
    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<GetListCarItemDto>>
    {
        private IMapper _mapper;
        private ICarRepository _repository;

        public GetListCarQueryHandler(IMapper mapper, ICarRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetListResponse<GetListCarItemDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _repository.GetListAsync
                (index :  request.PageRequest.PageIndex, size: request.PageRequest.PageSize);
            GetListResponse<GetListCarItemDto> response = _mapper.Map<GetListResponse<GetListCarItemDto>>(cars);
            return (response);
        }
    }
}
