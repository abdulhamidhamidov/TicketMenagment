using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class TicketServices(DapperConText dapperConText):IAllServices<Ticket>
{
    public Response<bool> Create(Ticket t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Tickets(Type, Title, Price, EventDateTime) values (@Type, @Title, @Price, @EventDateTime);\n";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully created");
    }

    public Response<List<Ticket>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Tickets;";
        var res = connection.Query<Ticket>(sql).ToList();
        return new Response<List<Ticket>>(res);
    }

    public Response<Ticket> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from Tickets where TicketId=@Id;";
        var res = connection.QuerySingle<Ticket>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Ticket>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Ticket>(res);     
    }

    public Response<bool> Update(Ticket t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Tickets set Type=@Type, Title=@Title, Price=@Price, EventDateTime=@EventDateTime where TicketId=@Id;";
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
        var sql = "delete from Tickets where TicketId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");

        
    }   
}