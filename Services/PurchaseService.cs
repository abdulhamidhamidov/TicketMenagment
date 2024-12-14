using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class PurchaseService(DapperConText dapperConText): IAllServices<Purchase>
{
    public Response<bool> Create(Purchase t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Purchases(ticketid, customerid, purchasedatetime, quantity, totalprice) values (@TicketId, @CustomerId, @PurchaseDateTime, @Quantity, @TotalPrice);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully created");

    }

    public Response<List<Purchase>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Purchases;\n";
        var res = connection.Query<Purchase>(sql).ToList();
        return new Response<List<Purchase>>(res);
    }

    public Response<Purchase> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Purchases where PurchaseId=@Id;";
        var res = connection.QuerySingle<Purchase>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Purchase>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Purchase>(res);    
    }
    public Response<bool> Update(Purchase t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Purchases set ticketid=@TicketId, customerid=@CustomerId, purchasedatetime=@PurchaseDateTime, quantity=@Quantity, totalprice@TotalPrice where PurchaseId=@Id;\n";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully update");

    }

    public Response<bool> Delete(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "delete from Purchases where PurchaseId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");

        
    }  
}

