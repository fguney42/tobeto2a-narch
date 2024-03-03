using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;
public class CreatedCarResponse
{
    public string Name { get; set; }
    public int ColorId { get; set; }
    public int ModelName {  get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
     // public Guid ModelId { get; set; }
}
