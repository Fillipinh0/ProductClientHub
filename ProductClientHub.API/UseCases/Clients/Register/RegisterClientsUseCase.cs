using ProductClientHub.Caommunication.Responses;
using ProductClientHub.Caommunication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;
using ProductClientHub.API.Infraestructure;
using ProductClientHub.API.Entities;
using ProductClientHub.API.UseCases.Clients.SheredValidator;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientsUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {
            Validate(request);
            var dbContext = new ProductClientHubDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email
            };

            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortClientJson() 
            {
                Id = entity.Id,
                Name = entity.Name,

            };
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
