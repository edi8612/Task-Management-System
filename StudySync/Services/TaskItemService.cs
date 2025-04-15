using System;
using AutoMapper;
using StudySync.Dtos;
using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskRepository;
    private readonly IUserRepository _userRepository; // Assuming you have a user repository
    private readonly IMapper _mapper;

    // Constructor with dependency injection
    public TaskItemService(ITaskItemRepository taskRepository, IUserRepository userRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // Step 1: Basic pass-through implementations
    public async Task<TaskItemDTO> GetTaskByIdAsync(int id)
    {
        var taskItem = await _taskRepository.GetTaskByIdAsync(id);

        return _mapper.Map<TaskItemDTO>(taskItem);
    }

    public async Task<IEnumerable<TaskItemDTO>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();
        return  _mapper.Map<IEnumerable<TaskItemDTO>>(tasks);
    }

    public async Task<IEnumerable<TaskItemDTO>> GetIncompleteTasksAsync()
    {
        var incompleteTasks = await _taskRepository.GetIncompleteTasksAsync();
        return _mapper.Map<IEnumerable<TaskItemDTO>>(incompleteTasks);

        

    }

    public async Task<TaskItemDTO> CreateTaskAsync(TaskItemCreateDTO taskCreateDto)
    {
        if (string.IsNullOrWhiteSpace(taskCreateDto.Title))
        {
            throw new ArgumentException("Task title cannot be empty.");
        }

        // Validate due date
        if (taskCreateDto.DueDate < DateTime.Now)
        {
            throw new ArgumentException("Due date must be in the future.");
        }

        // Validate priority
        if (taskCreateDto.Priority != "Low" && taskCreateDto.Priority != "Medium" && taskCreateDto.Priority != "High")
        {
            throw new ArgumentException("Priority must be 'Low', 'Medium', or 'High'.");
        }

        var taskItem = _mapper.Map<TaskItem>(taskCreateDto);

        taskItem.IsCompleted = false; // Default to not completed
        await _taskRepository.AddTaskAsync(taskItem);

        return _mapper.Map<TaskItemDTO>(taskItem);

    }

    public async Task UpdateTaskAsync(TaskItemUpdateDTO updateDto, int id)
    {
        // Validate task title
        if (string.IsNullOrWhiteSpace(updateDto.Title))
        {
            throw new ArgumentException("Task title cannot be empty.");
        }

        // Validate priority
        if (updateDto.Priority != "Low" && updateDto.Priority != "Medium" && updateDto.Priority != "High")
        {
            throw new ArgumentException("Priority must be 'Low', 'Medium', or 'High'.");
        }
        
        var taskItem = await _taskRepository.GetTaskByIdAsync(id);
        if (taskItem == null)
        {
            throw new KeyNotFoundException($"Task with ID {id} not found.");
        }

        _mapper.Map(updateDto, taskItem); // Map the updated properties
        await _taskRepository.UpdateTaskAsync(taskItem);
    }

    public async Task DeleteTaskAsync(int id)
    {
        await _taskRepository.DeleteTaskAsync(id);
    }

    // Step 3: Implement business logic for toggling task completion
    public async Task<bool> ToggleTaskCompletionAsync(int id)
    {
        try
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
                
            // Toggle the completion status
            task.IsCompleted = !task.IsCompleted;
                
            // Update the task
            await _taskRepository.UpdateTaskAsync(task);
                
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
        
    // New implementations
    public async Task<IEnumerable<TaskItemDTO>> GetTasksByPriorityAsync(string priority)
    {
        // Validate priority
        if (priority != "Low" && priority != "Medium" && priority != "High")
        {
            throw new ArgumentException("Priority must be 'Low', 'Medium', or 'High'.");
        }
            
        var filteredTasks = (await _taskRepository.GetAllTasksAsync()).Where(t => t.Priority == priority);
        return _mapper.Map<IEnumerable<TaskItemDTO>>(filteredTasks);

    }
        
    public async Task<IEnumerable<TaskItemDTO>> GetUpcomingTasksAsync(int days)
    {
        // Validate days parameter
        if (days <= 0)
        {
            throw new ArgumentException("Number of days must be positive.");
        }

        // Calculate the date range
        var endDate = DateTime.Now.AddDays(days);
            
        // Get all tasks and filter by due date
        var allTasks = await _taskRepository.GetAllTasksAsync();

        var filteredTasks = allTasks.Where(t => t.DueDate >= DateTime.Now && t.DueDate <= endDate)
            .OrderBy(t => t.DueDate);

        return _mapper.Map<IEnumerable<TaskItemDTO>>(filteredTasks);
    }

    public async Task AssignTaskToUserAsync(int taskId, int userId)
    {
        // Verify task exists
        var task = await _taskRepository.GetTaskByIdAsync(taskId);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task with ID {taskId} not found.");
        }

        // Verify user exists
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {userId} not found.");
        }

        // Update the task's UserId
        task.UserId = userId;
            
        // Save the changes
        await _taskRepository.UpdateTaskAsync(task);
    }
}

