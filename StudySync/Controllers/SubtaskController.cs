using Microsoft.AspNetCore.Mvc;
using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Controllers;

[ApiController]
[Route("[controller]")]
public class SubtaskController : ControllerBase
{
    private readonly ISubtaskRepository _subtaskRepository;

    public SubtaskController(ISubtaskRepository subtaskRepository)
    {
        _subtaskRepository = subtaskRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subtask>>> GetSubtasks()
    {
        var subtasks = await _subtaskRepository.GetAllSubtasksAsync();
        return Ok(subtasks);
    }

    [HttpGet("task/{taskId}")]
    public async Task<ActionResult<IEnumerable<Subtask>>> GetSubtasksByTaskId(int taskId)
    {
        var subtasks = await _subtaskRepository.GetSubtasksByTaskIdAsync(taskId);
        return Ok(subtasks);
    }

   
}