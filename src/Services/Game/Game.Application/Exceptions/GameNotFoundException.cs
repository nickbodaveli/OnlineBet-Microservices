using BuildingBlocks.Exceptions;

namespace Game.Application.Exceptions
{
    internal class GameNotFoundException : NotFoundException
    {
        public GameNotFoundException(Guid id) : base("Game", id)
        {
        }
    }
}
