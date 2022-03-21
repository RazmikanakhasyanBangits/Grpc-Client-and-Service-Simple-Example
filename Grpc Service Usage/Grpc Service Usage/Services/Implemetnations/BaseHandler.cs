using GrpcGreeterClient;
using AutoMapper;
namespace Grpc_Service_Usage.Services
{
    public class BaseHandler : IBaseHandler
    {
        private readonly IMapper mapper;

        public BaseHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<responseModel> HandleAsync(Task<List<MyModel>> Model, requestModel request)
        {
            try
            {
                if (!Model.Result.Any(x => x.Name == request.Name))
                    throw new ArgumentNullException();


                var User = Model.Result.FirstOrDefault(x => x.Name == request.Name);

                var m = mapper.Map<responseModel>(User);

                return Task.FromResult(m);

            }
            catch (ArgumentNullException)
            {

                return Task.FromResult(new responseModel
                {
                    Age = 0,
                    Name = "Unknown",
                    Surname = "Unknown",
                    Birthdate = "Unknown",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(new responseModel
                {
                    Age = 0,
                    Name = "Unknown",
                    Surname = "Unknown",
                    Birthdate = "Unknown",
                });
            }
        }
    }
}
