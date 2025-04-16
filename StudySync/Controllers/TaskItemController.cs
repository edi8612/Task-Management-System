using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudySync.Dtos;
using StudySync.Models;
using StudySync.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudySync.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskService;

        // Step 4: Updated constructor to inject the service instead of repository
        public TaskItemController(ITaskItemService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        // [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDTO>> GetSingleTask(int id)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                return Ok(task);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> CreateTask(TaskItemCreateDTO createDto)
        {
            try
            {
               var createdTask = await _taskService.CreateTaskAsync(createDto);
                return CreatedAtAction(
                    nameof(GetSingleTask),
                    new { id = createdTask.Id },
                    createdTask);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItemUpdateDTO updateDto)
        {
            try
            {
                await _taskService.UpdateTaskAsync(updateDto, id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpDelete("api/Tasks/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                await _taskService.DeleteTaskAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }




        // New endpoint for toggling task completion
        [HttpPatch("{id}/toggle-completion")]
        public async Task<IActionResult> ToggleTaskCompletion(int id)
        {
            var result = await _taskService.ToggleTaskCompletionAsync(id);
            
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        
        // GET: api/TaskItem/priority/High
        [HttpGet("priority/{priority}")]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetTasksByPriority(string priority)
        {
            try
            {
                var tasks = await _taskService.GetTasksByPriorityAsync(priority);
                return Ok(tasks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/TaskItem/upcoming/7
        [HttpGet("upcoming/{days}")]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetUpcomingTasks(int days)
        {
            try
            {
                var tasks = await _taskService.GetUpcomingTasksAsync(days);
                return Ok(tasks);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/TaskItem/5/assign/2
        [HttpPost("{taskId}/assign/{userId}")]
        public async Task<IActionResult> AssignTaskToUser(int taskId, int userId)
        {
            try
            {
                await _taskService.AssignTaskToUserAsync(taskId, userId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}