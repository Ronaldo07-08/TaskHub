namespace Api.Controllers.Tasks.Request
{
    public record CreateTaskRequest
    {

        public Guid UserId { get; set; }

        public string? TaskTitle { get; set; }

    }
}
