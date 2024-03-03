using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Queries;
public class GetListIndividualCustomerItemDto
{
    public string? FirstName {  get; set; }
    public string? LastName {  get; set; }
    public string? Email {  get; set; }
    public string? Password {  get; set; }
    public string? NationalIdentity {  get; set; }
}
