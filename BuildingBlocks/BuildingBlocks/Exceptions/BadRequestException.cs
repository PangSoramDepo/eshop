namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public string? Detail { get; }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, string detail) : base(message)
        {
            Detail = detail;
        }
    }
}
