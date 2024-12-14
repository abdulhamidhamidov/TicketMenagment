using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class TicketController(IAllServices<Ticket> carServices) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Ticket ticket) => carServices.Create(ticket);
    [HttpGet]
    public Response<List<Ticket>> GetAll() => carServices.GetAll();
    [HttpGet("/get-By-Id-Car")]
    public Response<Ticket> GetById(int id) => carServices.GetById(id);
    [HttpPut]
    public  Response<bool>  Update(Ticket ticket) => carServices.Update(ticket);
    [HttpDelete]
    public  Response<bool>  Delete(int id) => carServices.Delete(id);
}

