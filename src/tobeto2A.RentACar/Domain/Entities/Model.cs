using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Model : Entity<Guid>
{
    public Guid BrandId { get; set; } //
    public Guid FuelId { get; set; } // Database İlişki gereksinimi//
    public Guid TransmissionId { get; set; }//
    public string Name { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }

    public Model()
    {
        Brand = null;
        Fuel = null;
        Transmission = null;
        Cars = null;
    }
    public Brand? Brand { get; set; }
    public Fuel? Fuel { get; set; }
    public Transmission? Transmission { get; set; }       // Ef Gereksinimi //
    public ICollection<Car>? Cars { get; set; }

    //public Model(Guid brandId, Guid fuelId, Guid transmissionId, string name, short year, decimal dailyPrice)
    //{
    //    BrandId = brandId;
    //    FuelId = fuelId;
    //    TransmissionId = transmissionId;
    //    Name = name;
    //    Year = year;
    //    DailyPrice = dailyPrice;
    //}
}
