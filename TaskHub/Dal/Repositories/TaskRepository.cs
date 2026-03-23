using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class TaskRepository : IRepoTasks
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntity> CreateTask(string? title, Guid userId, CancellationToken token)
        {
            try
            {
                var entity = new TaskEntity(Guid.NewGuid(), title, userId, DateTimeOffset.UtcNow);
                _dbContext.Tasks.Add(entity);
                await _dbContext.SaveChangesAsync(token);
                return entity;
            }
            catch (DbUpdateException)
            {
                throw new Exception($"Пользователь с ID {userId} не найден в базе данных.");
            }
        }

        public async Task<List<TaskEntity>> GetTasks(CancellationToken token)
        {
            return await _dbContext.Tasks.ToListAsync(token);
        }

        public async Task<TaskEntity?> GetTask(Guid taskId, CancellationToken token)
        {

            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId, token);
        }

        public async Task<TaskEntity?> SetTaskTitle(Guid taskId, string? title, CancellationToken token)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId, token);

            if (task == null) return null;

            task.Title = title;
            await _dbContext.SaveChangesAsync(token);

            return task;
        }

        public async Task<bool> DeleteTask(Guid taskId, CancellationToken token)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId, token);

            if (task == null) return false;

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task DeleteTasks(CancellationToken token)
        {
            var allTasks = await _dbContext.Tasks.ToListAsync(token);
            _dbContext.Tasks.RemoveRange(allTasks);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
