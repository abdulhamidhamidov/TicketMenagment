using System.Net;

namespace WebApiDapper.ApiResponse;

public class Response<T>
{
    public int StatuseCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }

    public Response(T data)
    {
        Data = data;
        StatuseCode = 200;
        Message = "";
    }
    public Response(HttpStatusCode statusCode,string message)
    {
        Data = default;
        StatuseCode = (int)statusCode;
        Message = message;
    }
}