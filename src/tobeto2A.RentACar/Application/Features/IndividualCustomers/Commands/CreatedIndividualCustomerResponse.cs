using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands;
public class CreatedIndividualCustomerResponse 
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { set; get; }
    public string? Password { set; get; }
    public string? NationalIdentity { get; set; }
}
