using System.Net;
using Dapper;
using Npgsql;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class TicketLocationService(DapperConText dapperConText): IAllServices<TicketLocation>
{
    public Response<bool> Create(TicketLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into TicketLocations(TicketId, locationid) values (@TicketId, @LocationId);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.Created, "Studnet successfully created");
    }

    public Response<List<TicketLocation>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from TicketLocations;";
        var res = connection.Query<TicketLocation>(sql).ToList();
        return new Response<List<TicketLocation>>(res);
    }

    public Response<TicketLocation> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from TicketLocations where TicketId=@TicketId;";
        var res = connection.QuerySingle<TicketLocation>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<TicketLocation>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<TicketLocation>(res);    
    }

    public Response<bool> Update(TicketLocation t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update TicketLocations set TicketId=@TicketId,LocationId=@LocationId where id=@Id;";
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
        var sql = "delete from TicketLocations where Id=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");
        
    }
}