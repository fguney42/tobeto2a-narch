using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Customer : Entity<Guid>
{
    public string? CustomerNo { set; get; }
    public Guid UserId { get; set; }
    public virtual User? User { set; get; } // Field yapar isen sadece metotları kullanabilirsin//
    public virtual IndividualCustomer? IndividualCustomer { set; get; }
    public virtual CorporateCustomer? CorporateCustomer{ set; get; }
    // Koleksiyon varsa constructor eklemelisin.//
}
