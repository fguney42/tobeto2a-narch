using Application.Features.Brands.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Constants;

namespace Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ISecuredRequest, ILoggableRequest, IIntervalRequest
{ // ADD C(rud) // Request Type() // // Handle??
    public string? Name { get; set; }
    public string? Logo { get; set; }

    public string[] Roles => new string[]
    { BrandOperationClaims.Write, BrandOperationClaims.Create }; // Role setted //
    public int Interval => 3; // Get ama => bu operator sayesinde içerisinde sabit bir değer tutabiliriz.//

    // Brand.Add // Brand.Delete // Brand.Update//

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
            _brandRepository = brandRepository;  // ::Servisler kod tekrarını onlemek için kullanılır:: //
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
            return;
        }
        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            //CancellationTokenSource cancellationTokenSource = new();
            ///*// async //*/
            //cancellationToken = cancellationTokenSource.Token;   //  Canceled processing//
            //Task task = Task.Run(()=>Task.Delay(5000),cancellationToken);
            //cancellationTokenSource.Cancel();
            //await Task.Delay(5000);
            // Thread.Sleep() for sync version.//
            await _brandBusinessRules.CarShouldNotExistsWithSameName(request.Name);
            Brand brand = _mapper.Map<Brand>(request); // Mappleme
            Brand addedBrand = await _brandRepository.AddAsync(brand); // Add //
            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(addedBrand);
            return (createdBrandResponse);
        }
    }
}
