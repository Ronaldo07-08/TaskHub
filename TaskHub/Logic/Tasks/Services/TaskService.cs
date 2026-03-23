using Dal.Repositories.Interfaces;
using Logic.Tasks.Models;
using Logic.Tasks.Services.Interfaces;


namespace Logic.Tasks.Services
{
    public class TaskService : ITaskService
    {

        IRepoTasks _repo;

        public TaskService(IRepoTasks repo)
        {
            _repo = repo;
        }

        public async Task<TaskModel> CreateTask(string? title, Guid userId, CancellationToken token)
        {
            var taskCreated = await _repo.CreateTask(title, userId, token);

            if (taskCreated.Title == null)
                return new TaskModel(taskCreated.Id, "", taskCreated.CreatedByUserId, taskCreated.CreatedUtc);
            return new TaskModel(taskCreated.Id, taskCreated.Title, taskCreated.CreatedByUserId, taskCreated.CreatedUtc);
        }

        public async Task DeleteAllTasks(CancellationToken token)
        {
            await _repo.DeleteTasks(token);
            return;
        }

        public async Task<bool> DeleteTaskById(Guid taskId, CancellationToken token)
        {

            return await _repo.DeleteTask(taskId, token);
        }

        public async Task<List<TaskModel>> GetAllTasks(CancellationToken token)
        {
            var tasks = await _repo.GetTasks(token);
            return tasks.ConvertAll(task => new TaskModel(task.Id, task.Title != null ? task.Title : "", task.CreatedByUserId, task.CreatedUtc));
        }

        public async Task<TaskModel?> GetTaskById(Guid taskId, CancellationToken token)
        {
            var task = await _repo.GetTask(taskId, token);

            if (task == null)
                return null;

            return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }

        public async Task<TaskModel?> SetTaskTitle(string? title, Guid taskId, CancellationToken token)
        {
            var task = await _repo.SetTaskTitle(taskId, title, token);
            if (task == null)
                return null;
            return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }
    }
}
