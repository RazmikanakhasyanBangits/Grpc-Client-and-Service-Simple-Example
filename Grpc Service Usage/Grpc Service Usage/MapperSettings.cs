using AutoMapper;
using GrpcGreeterClient;

namespace Grpc_Service_Usage
{
    public class MapperSettings:Profile
    {
        public MapperSettings()
        {
            CreateMap<MyModel, responseModel>();
        }
    }
}
