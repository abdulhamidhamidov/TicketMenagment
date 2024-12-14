using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class TicketLocationController(IAllServices<TicketLocation> carLocationService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(TicketLocation ticketLocation) => carLocationService.Create(ticketLocation);
    [HttpGet]
    public Response<List<TicketLocation>> GetAll() => carLocationService.GetAll();
    [HttpGet("/get-By-Id-CarLocation")]
    public Response<TicketLocation> GetById(int id) =>carLocationService.GetById(id);
    [HttpPut]
    public Response<bool> Update(TicketLocation ticketLocation) => carLocationService.Update(ticketLocation);
    [HttpDelete]
    public Response<bool> Delete(int id) => carLocationService.Delete(id);
}

