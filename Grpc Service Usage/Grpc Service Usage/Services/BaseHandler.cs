using GrpcGreeterClient;

namespace Grpc_Service_Usage.Services
{
    public class BaseHandler
    {
        public static Task<responseModel> HandleAsync(Task<List<MyModel>> Model,requestModel request)
        {
            try { 

            if (!Model.Result.Contains(Model.Result.FirstOrDefault(x => x.Name == request.Name)))
                throw new ArgumentNullException();

            var GetUser = new responseModel
            {
                Age = Convert.ToInt32(Model.Result.FirstOrDefault(x => x.Name == request.Name).Age),
                Name = Model.Result.FirstOrDefault(x => x.Name == request.Name).Name,
                Surname = Model.Result.FirstOrDefault(x => x.Name == request.Name).Surname,
                Birthdate = DateTime.UtcNow.ToString()
            };
            return Task.FromResult(GetUser);

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
