using System.Text;
using System.Text.Json;
using BuildingBlocks.CQRS;
using Game.Application.Data;

namespace Game.Application.Bets.Commands
{
    public class CreateBetCommandHandler(IApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
     : ICommandHandler<CreateBetCommand, CreateBetResult>
    {
        public async Task<CreateBetResult> Handle(CreateBetCommand command, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient("ApiGatewayClient");

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var response = await httpClient.PostAsync("hub-service/bet", jsonContent);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CreateBetResult>(responseJson);

            return new CreateBetResult(result.Id);
        }
    }
}
