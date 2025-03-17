namespace BuildingBlocks.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message)
        {
        }

        public AlreadyExistException(string message, string details) : base(message)
        {
            Details = details;
        }

        public string? Details { get; }
    }
}
