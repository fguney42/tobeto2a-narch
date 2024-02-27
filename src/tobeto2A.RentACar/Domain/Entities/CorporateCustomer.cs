using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CorporateCustomer : Entity<Guid>
{
    public string Name { get; set; }
    public string TaxNo { set; get; }
    Customer customer { set; get; }
    public CorporateCustomer()
    {
        
    }
}
