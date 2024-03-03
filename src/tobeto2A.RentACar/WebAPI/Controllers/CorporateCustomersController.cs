using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries;
using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpPost]

    public async Task<CreatedCorporateCustomerResponse> Add(CreateCorporateCustomerCommand command)
    {
        var result = await Mediator.Send(command); // Design pattern
        return result;
    }
    [HttpGet()]
    public async Task<GetListResponse<GetListCorporateCustomerItemDto>> GetList([FromQuery]PageRequest request)
    {
        GetListCorporateCustomerQuery corporateCustomer = new() { PageRequest = request };
        GetListResponse<GetListCorporateCustomerItemDto> response = await Mediator.Send(corporateCustomer);
        return (response);
    }
}
