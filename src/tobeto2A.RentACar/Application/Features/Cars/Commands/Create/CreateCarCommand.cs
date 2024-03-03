using Application.Features.Brands.Commands.Create;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;
public class CreateCarCommand : IRequest<CreatedCarResponse>
{
    public int ColorId { get; set; }
    public string BrandName { get; set; }
    public string ColorName { get; set; }
    public int CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public string ModelName { get; set; }
    public Guid ModelId { get; set; }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly IMapper _mapper;
        private  CarBusinessRules _carBusinessRules;
        private  ICarRepository _repository;
        public CreateCarCommandHandler(IMapper mapper, CarBusinessRules carBusinessRules, ICarRepository repository)
        {
            _mapper = mapper; 
            _carBusinessRules = carBusinessRules;
            _repository = repository;             
            return;
        }
        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carBusinessRules.CheckIfCarNotExists(request);
            Car car = _mapper.Map<Car>(request);
            Car addedCar = _repository.Add(car);
            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(addedCar);
            return response;
        }
    }
}
