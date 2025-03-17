namespace Hub.Application.Dtos
{
    public record BetDto
    (
        int UserId,
        int GameId,
        decimal Amount,
        DateTime Timestamp
    );
}
