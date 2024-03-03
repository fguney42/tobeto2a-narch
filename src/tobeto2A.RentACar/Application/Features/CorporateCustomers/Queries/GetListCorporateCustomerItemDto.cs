using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries;
public class GetListCorporateCustomerItemDto
{
    public GetListCorporateCustomerItemDto()
    { }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TaxNo { set; get; }
}
