using ProductClientHub.Caommunication.Responses;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class ResponseAllClientsJson
    {
        public List<ResponseShortClientJson> Clients { get; set; } = [];
    }
}
