using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class CustomerService(DapperConText dapperConText): IAllServices<Customer>
{
    public Response<bool> Create(Customer t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Customers(fullname,email, phone, ) values (@FullName,@Email,@Phone);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully created");
    }

    public Response<List<Customer>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Customers;";
        var res = connection.Query<Customer>(sql).ToList();
        return new Response<List<Customer>>(res);
    }

    public Response<Customer> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Cars where CarId=@Id;";
        var res = connection.QuerySingle<Customer>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Customer>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Customer>(res);    
    }
    public Response<bool> Update(Customer t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Customers set fullname=@FullName,email=@Email,phone=@Phone where CustomerId=@Id;";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully update");  
    }

    public Response<bool> Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Customers where CustomerId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully delete");
    }      
}