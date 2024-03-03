using Domain.Enums;
using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries;
public class GetListCarItemDto
{
    public int ColorId { get; set; }
    public int ModelName { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string? Plate { get; set; }
}
