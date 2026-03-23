using Logic.Tasks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tasks.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<TaskModel> CreateTask(string? title, Guid userId, CancellationToken token);

        public Task<TaskModel?> GetTaskById(Guid taskId, CancellationToken token);

        public Task<List<TaskModel>> GetAllTasks(CancellationToken token);

        public Task<TaskModel?> SetTaskTitle(string? title, Guid taskId, CancellationToken token);

        public Task<bool> DeleteTaskById(Guid taskId, CancellationToken token);

        public Task DeleteAllTasks(CancellationToken token);

    }
}
