using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class PurchaseController(IAllServices<Purchase> retalService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Purchase purchase) => retalService.Create(purchase);
    [HttpGet("/get-All")]
    public Response<List<Purchase>> GetAll() => retalService.GetAll();
    [HttpGet("/get-By-Id")]
    public Response<Purchase> GetById(int id) =>retalService.GetById(id);
    [HttpPut]
    public Response<bool> Update(Purchase purchase) => retalService.Update(purchase);
    [HttpDelete]
    public Response<bool> Delete(int id) => retalService.Delete(id);
}