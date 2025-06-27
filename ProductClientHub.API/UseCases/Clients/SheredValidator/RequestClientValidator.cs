using FluentValidation;
using ProductClientHub.Caommunication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SheredValidator
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(ClientCertificateOption => ClientCertificateOption.Name).NotEmpty().WithMessage("O nome nao pode ser vazio");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O email nao e valido");
        }
    }
}
