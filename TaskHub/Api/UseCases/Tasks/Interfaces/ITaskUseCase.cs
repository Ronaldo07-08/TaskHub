using Api.Controllers.Tasks.Response;

namespace Api.UseCases.Tasks.Interfaces
{
    public interface ITaskUseCase
    {

        public Task<TaskResponse> CreateTaskUseCase(string? title, Guid userId, CancellationToken token);

        public Task<List<TaskResponse>> GetTasksUseCase(CancellationToken token);

        public Task<TaskResponse?> GetTaskUseCase(Guid taskId, CancellationToken token);

        public Task<TaskResponse?> SetTaskTitleUseCase(string? title, Guid taskId, CancellationToken token);

        public Task<bool> DeleteTaskUseCase(Guid taskId, CancellationToken token);

        public Task DeleteTasksUseCase(CancellationToken token);
    }
}
