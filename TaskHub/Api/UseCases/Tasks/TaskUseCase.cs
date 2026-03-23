using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Logic.Tasks.Services.Interfaces;

namespace Api.UseCases.Tasks
{
    public class TaskUseCase : ITaskUseCase
    {

        public ITaskService _taskService;

        public TaskUseCase(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<TaskResponse> CreateTaskUseCase(string? title, Guid userId, CancellationToken token)
        {
            var taskCreated = await _taskService.CreateTask(title, userId, token);

            return new TaskResponse(taskCreated.Id, taskCreated.Title, taskCreated.CreatedByUserId, taskCreated.CreatedUtc);
        }

        public async Task DeleteTasksUseCase(CancellationToken token)
        {
            await _taskService.DeleteAllTasks(token);
            return;
        }

        public async Task<bool> DeleteTaskUseCase(Guid taskId, CancellationToken token)
        {
            return await _taskService.DeleteTaskById(taskId, token);
        }

        public async Task<List<TaskResponse>> GetTasksUseCase(CancellationToken token)
        {
            var tasks = await _taskService.GetAllTasks(token);
            return tasks.ConvertAll(task => new TaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc));
        }

        public async Task<TaskResponse?> GetTaskUseCase(Guid taskId, CancellationToken token)
        {
            var task = await _taskService.GetTaskById(taskId, token);

            if (task == null)
                return null;

            return new TaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }

        public async Task<TaskResponse?> SetTaskTitleUseCase(string? title, Guid taskId, CancellationToken token)
        {
            var task = await _taskService.SetTaskTitle(title, taskId, token);
            if (task == null)
                return null;

            return new TaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }
    }
}
