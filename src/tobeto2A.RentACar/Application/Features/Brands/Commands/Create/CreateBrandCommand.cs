using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{ // ADD C(rud) // Request Type()
    public string Name { get; set; }
    public string Logo{ get; set; }

    // Inner Class
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand,
        CreatedBrandResponse> // Web api'deki Mediator için //
    {
        private readonly IBrandRepository _brandRepository;
        private IMapper _mapper;
        private BrandBusinessRules _brandBusinessRules;
        // Constructor Injection // 
        public CreateBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper,BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository; 
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }
        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.CarShouldNotExistsWithSameName(request.Name);
            Brand brand = _mapper.Map<Brand>(request); // Mappleme
            Brand addedBrand = await _brandRepository.AddAsync(brand); // Add //
            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(addedBrand);
            return (createdBrandResponse);
        }
    }
}
