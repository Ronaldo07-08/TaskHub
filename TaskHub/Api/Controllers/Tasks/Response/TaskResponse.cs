namespace Api.Controllers.Tasks.Response
{
    public class TaskResponse
    {

        public TaskResponse(Guid id, string? title, Guid userId, DateTimeOffset createdUtc)
        {
            Id = id;
            Title = title;
            CreatedByUserId = userId;
            CreatedUtc = createdUtc;
        }

        public Guid Id { get; set; }

        public string? Title { get; set; }

        public Guid CreatedByUserId { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
