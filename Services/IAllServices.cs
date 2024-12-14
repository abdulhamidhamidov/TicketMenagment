using WebApiDapper.ApiResponse;

namespace WebApiDapper.Services;

public interface IAllServices<T>
{
    Response<bool> Create(T t);
    Response<List<T>> GetAll();
    Response<T> GetById(int id);
    Response<bool> Update(T t);
    Response<bool> Delete(int id);
}