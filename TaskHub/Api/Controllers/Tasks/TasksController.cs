using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.Hw.Filters_task;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks
{
    [ApiController]
    [Route("tasks")]
    [StudentInfoHeadersFilter]
    [RequestLoggingFilter]
    public class TasksController : ControllerBase
    {
        private readonly ITaskUseCase _taskUseCase;

        public TasksController(ITaskUseCase taskUseCase)
        {
            _taskUseCase = taskUseCase;
        }

        [HttpPost]
        [ValidateCreateTaskRequestFilter]
        public async Task<ActionResult<TaskResponse>> CreateTaskAsync([FromBody] CreateTaskRequest request, CancellationToken token)
        {
            var resp = await _taskUseCase.CreateTaskUseCase(request.TaskTitle, request.UserId, token);
            return Ok(resp);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> GetAllTasks(CancellationToken token)
        {
            var resp = await _taskUseCase.GetTasksUseCase(token);
            return Ok(resp);
        }

        [HttpGet("{id:guid}")]//[HttpGet("{id}")]
        public async Task<ActionResult<TaskResponse>> GetTaskByID([FromRoute] Guid id, CancellationToken token) //[FromRouteTaskId]
        {
            var resp = await _taskUseCase.GetTaskUseCase(id, token);

            if (resp == null)
                return NotFound();

            return Ok(resp);
        }

        [HttpPut("{id:guid}/title")]
        [ValidateSetTaskTitleRequestFilter]
        public async Task<IActionResult> UpdateTaskName([FromBody] SetTaskTitleRequest request, [FromRoute] Guid id, CancellationToken token)
        {
            var resp = await _taskUseCase.SetTaskTitleUseCase(request.Title, id, token);

            if (resp == null)
                return NotFound();
            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTaskByID([FromRoute] Guid id, CancellationToken token)
        {
            var resp = await _taskUseCase.DeleteTaskUseCase(id, token);

            if (!resp)
                return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllTasks(CancellationToken token)
        {
            await _taskUseCase.DeleteTasksUseCase(token);

            return NoContent();
        }
    }
}
