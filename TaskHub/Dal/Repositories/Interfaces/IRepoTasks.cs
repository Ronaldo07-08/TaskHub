using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories.Interfaces
{
    public interface IRepoTasks
    {
        public Task<TaskEntity> CreateTask(string? title, Guid userId, CancellationToken token);

        public Task<List<TaskEntity>> GetTasks(CancellationToken token);

        public Task<TaskEntity?> GetTask(Guid taskId, CancellationToken token);

        public Task<TaskEntity?> SetTaskTitle(Guid taskId, string? title, CancellationToken token);

        public Task<bool> DeleteTask(Guid taskId, CancellationToken token);

        public Task DeleteTasks(CancellationToken token);


    }
}
