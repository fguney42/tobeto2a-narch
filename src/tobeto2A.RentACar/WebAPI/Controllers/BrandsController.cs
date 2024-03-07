using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CreateBrandCommand command)
    {
        CancellationToken token = new CancellationToken();
        CreatedBrandResponse response = await Mediator.Send(command,token); 
        // Doğrudan bağımlılık azaltma // Handle CreateBrandCommandHandler.Handle() //
        return Created("",response);
        // 201 Http Status Code returned // 
        // Urisiz VERİ KAYNAĞI NULL ayarladık
    }
    [HttpGet]

    public async Task<IActionResult>? GetAll([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery query = new GetListBrandQuery() { PageRequest = pageRequest };
        var response = await Mediator.Send(query); /////
        return Created("",response);
    }
}
