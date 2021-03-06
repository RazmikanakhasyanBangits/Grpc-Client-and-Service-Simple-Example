using Grpc.Core;
using Grpc_Service_Usage;
using GrpcGreeterClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Grpc_Service_Usage.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IMapper mapper;
        private readonly IBaseHandler baseHandler;
        public GreeterService(ILogger<GreeterService> logger, IMapper mapper, IBaseHandler baseHandler)
        {
            this.baseHandler = baseHandler;
            this.mapper = mapper;
            _logger = logger;
        }

        public Task<List<MyModel>> AddDataAsync(List<MyModel> model)
        {
            #region Add To List
            model.Add(new MyModel
            {
                Name = "Razmik0",
                Surname = "Anakhasyan",
                Age = 18,
                BirthDate = DateTime.UtcNow
            });
            model.Add(new MyModel
            {
                Name = "Razmik1",
                Surname = "Anakhasyan",
                Age = 19,
                BirthDate = DateTime.UtcNow
            });
            model.Add(new MyModel
            {
                Name = "Razmik2",
                Surname = "Anakhasyan",
                Age = 20,
                BirthDate = DateTime.UtcNow
            });
            model.Add(new MyModel
            {
                Name = "Razmik3",
                Surname = "Anakhasyan",
                Age = 21,
                BirthDate = DateTime.UtcNow
            });
            #endregion
            return Task.FromResult(model);
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
        public override async Task<responseModel> CustomReply(requestModel request, ServerCallContext context)
        {
            var data = AddDataAsync(new List<MyModel>());
            _logger.LogDebug("Getting Data");
            return await baseHandler.HandleAsync(data, request);
        }
    }

}