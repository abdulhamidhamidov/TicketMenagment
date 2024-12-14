using WebApiDapper.ApiResponse;
using WebApiDapper.Models;
using WebApiDapper.Services;

namespace WebApiDapper.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(IAllServices<Customer> customerService) : ControllerBase
{
    [HttpPost]
    public Response<bool> Create(Customer customer) => customerService.Create(customer);
    [HttpGet]
    public Response<List<Customer>> GetAll() => customerService.GetAll();
    [HttpGet("/get-By-Id-customer")]
    public Response<Customer> GetById(int id) =>customerService.GetById(id);
    [HttpPut]
    public Response<bool> Update(Customer customer) => customerService.Update(customer);
    [HttpDelete]
    public Response<bool> Delete(int id) => customerService.Delete(id);
}