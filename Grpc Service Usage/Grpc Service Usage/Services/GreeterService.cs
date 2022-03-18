using Grpc.Core;
using Grpc_Service_Usage;

namespace Grpc_Service_Usage.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
        public override Task<responseModel> CustomReply(requestModel request, ServerCallContext context)
        {
            foreach (var item in request)
            {

            }
            return Task.FromResult(new responseModel { MaxResult = 1000 });
        }
    }
}