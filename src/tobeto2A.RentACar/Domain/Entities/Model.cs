using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Model : Entity<Guid>
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }

    public Model()
    {
        
    }
    public Model(Guid brandId, Guid fuelId, Guid transmissionId, string name, short year, decimal dailyPrice)
    {
        BrandId = brandId;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        Year = year;
        DailyPrice = dailyPrice;
    }

    //public Brand? Brand { get; set; } = null;
    //public Fuel? Fuel { get; set; } = null; 
    //public Transmission? Transmission { get; set; } = null;

    //public ICollection<Car>? Cars { get; set; } = null;
}
