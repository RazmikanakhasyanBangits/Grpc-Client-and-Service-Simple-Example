using GrpcGreeterClient;
using AutoMapper;
namespace Grpc_Service_Usage.Services
{
    public class BaseHandler
    {
        private static AutoMapper.MapperConfiguration mapperConfiguration;
        public static Task<responseModel> HandleAsync(Task<List<MyModel>> Model,requestModel request)
        {
            mapperConfiguration = new(config =>
           config.CreateMap<MyModel, responseModel>());
            try { 

            if (!Model.Result.Contains(Model.Result.FirstOrDefault(x => x.Name == request.Name)))
                throw new ArgumentNullException();


                var GetUser = Model.Result.FirstOrDefault(x => x.Name == request.Name);
                var mapper = new Mapper(mapperConfiguration);
               

            return Task.FromResult(mapper.Map<responseModel>(GetUser));

        }
            catch (ArgumentNullException ex)
            {

                return Task.FromResult(new responseModel
                {
                    Age = 0,
                    Name ="Unknown",
                    Surname="Unknown",
                    Birthdate="Unknown",
                });
            }
        }
    }
}
