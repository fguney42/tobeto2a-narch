//using Application.Features.Brands.Commands.Create;
//using Application.Features.Brands.Queries;
using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpPost]
    public async Task<CreatedIndividualCustomerResponse> Add(CreateIndividualCustomerCommand command)
    {
        CreatedIndividualCustomerResponse response = await Mediator.Send(command);
        return (response);
    }
    [HttpGet]

    public async Task<GetListResponse<GetListIndividualCustomerItemDto>> GetList(PageRequest request)
    {
        GetListIndividualCustomerQuery query = new() { PageRequest = request };
        GetListResponse<GetListIndividualCustomerItemDto> response = await Mediator.Send(query);
        return (response);
    }
}
