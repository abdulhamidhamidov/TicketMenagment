using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class LocationController(IAllServices<Location> locationService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Location location) => locationService.Create(location);
    [HttpGet]
    public Response<List<Location>> GetAll() => locationService.GetAll();
    [HttpGet("/get-By-Id-location")]
    public Response<Location> GetById(int id) =>locationService.GetById(id);
    [HttpPut]
    public Response<bool> Update(Location location) => locationService.Update(location);
    [HttpDelete]
    public Response<bool> Delete(int id) => locationService.Delete(id);
}