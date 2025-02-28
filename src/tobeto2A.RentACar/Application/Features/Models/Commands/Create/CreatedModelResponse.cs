using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
    public Brand? Brand { get; set; }
    public Fuel? Fuel { get; set; }
    public Transmission? Transmission { get; set; }
}