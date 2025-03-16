using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Game.Application.Data;
using Mapster;

namespace Game.Application.Bets.Commands
{
    public class CreateBetCommandHandler(IApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
     : ICommandHandler<CreateBetCommand, CreateBetResult>
    {
        public async Task<CreateBetResult> Handle(CreateBetCommand command, CancellationToken cancellationToken)
        {
            //var httpClient = httpClientFactory.CreateClient("ApiGatewayClient");

            //// Call the game-service through YARP
            //var response = await httpClient.GetAsync("game-service/test"); // Use the correct route
            //response.EnsureSuccessStatusCode(); // Throws if not a success code
            //var test = await response.Content.ReadAsStringAsync();


            var httpClient = httpClientFactory.CreateClient("ApiGatewayClient");

            // Serialize the command to JSON
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            // Send the POST request
            var response = await httpClient.PostAsync("hub-service/bet", jsonContent);
            response.EnsureSuccessStatusCode(); // Throws if not a success code

            // Deserialize the response
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CreateBetResult>(responseJson);

            throw new NotImplementedException();
        }
    }
}
