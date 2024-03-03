using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules;
public class CarBusinessRules :BaseBusinessRules
{
    private readonly ICarRepository _carRepository;
    public CarBusinessRules(ICarRepository repository)
    {
        _carRepository = repository;
        return;
    }
    public async Task CheckIfCarNotExists(CreateCarCommand command)
    {
        bool result = _carRepository.Get(cr=>cr.Id.Equals(command.Plate)) != null;
        if (result)
        {
            throw new BusinessException(CarMessages.CarAlreadyExists);
        }
        return;
    }
}
