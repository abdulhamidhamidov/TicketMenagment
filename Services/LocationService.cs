using System.Net;
using Dapper;
using WebApiDapper.ApiResponse;
using WebApiDapper.DataConText;
using WebApiDapper.Models;

namespace WebApiDapper.Services;

public class LocationService(DapperConText dapperConText): IAllServices<Location>
{
    public Response<bool> Create(Location t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "insert into Locations(city, address,LocationType) values (@City, @Address,@LocationType);";
        var res = connection.Execute(sql,t);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully created");

    }

    public Response<List<Location>> GetAll()
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from  Locations;";
        var res = connection.Query<Location>(sql).ToList();
        return new Response<List<Location>>(res);
    }

    public Response<Location> GetById(int id)
    {
        using  var connection = dapperConText.Connection();
        var sql = "select * from  Locations where LocationId=@Id;";
        var res = connection.QuerySingle<Location>(sql,new {Id=id});
        if (res == null)
        {
            return new Response<Location>(HttpStatusCode.InternalServerError,"Student not found");
        }
        return new Response<Location>(res);    
    }
    public Response<bool> Update(Location t)
    {
        using  var connection = dapperConText.Connection();
        var sql = "update Locations set city=@City, address=@Address,LocationType=@LocationType where LocationId=@Id;";
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
        var sql = "delete from Locations where LocationId=@Id;";
        var res = connection.Execute(sql,new {Id=id});
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,"Student not found");
        }

        return new Response<bool>(HttpStatusCode.OK, "Studnet successfully delete");

    }      
}