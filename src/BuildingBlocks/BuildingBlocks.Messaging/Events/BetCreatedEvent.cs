namespace BuildingBlocks.Messaging.Events
{
    public record BetCreatedEvent : IntegrationEvent
    {
        public int UserId { get; set; } = default!;
        public int GameId { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
