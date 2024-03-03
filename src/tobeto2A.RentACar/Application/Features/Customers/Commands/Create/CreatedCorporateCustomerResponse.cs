﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Create;
public class CreatedCorporateCustomerResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? TaxNo { set; get; }
}
