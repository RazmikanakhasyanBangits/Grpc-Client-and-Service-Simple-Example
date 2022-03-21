using AutoMapper;
using GrpcGreeterClient;

namespace Grpc_Service_Usage
{
    public interface IBaseHandler
    {
        Task<responseModel> HandleAsync(Task<List<MyModel>> Model, requestModel request);
    }
}
