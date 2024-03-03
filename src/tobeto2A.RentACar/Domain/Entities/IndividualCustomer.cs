using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class IndividualCustomer : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { set; get; }
    public string Password { set; get; }
    public string NationalIdentity { get; set; }
    public IndividualCustomer()
    {
    }
}
