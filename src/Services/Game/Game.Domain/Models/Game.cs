using Domain.Abstractions.Abstractions;
using Game.Domain.ValueObjects;

namespace Game.Domain.Models
{
    public class Game : Aggregate<GameId>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
