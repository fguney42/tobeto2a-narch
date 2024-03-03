using Application.Features.Brands.Commands.Create;
using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController : BaseController
{
    [HttpPost()]
    public async Task <CreatedCarResponse> Add([FromBody] CreateCarCommand command)
    {
        CreatedCarResponse response  = await Mediator.Send(command); // Bağımlılık azaltma
        return response;
    }
    [HttpGet]
    public async Task<GetListResponse<GetListCarItemDto>>? GetAll([FromQuery] PageRequest request)
    {
        GetListCarQuery query = new GetListCarQuery() { PageRequest=request};
        var response = await Mediator.Send(query);
        return response;
    }
}
