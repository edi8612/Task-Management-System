using System;
using Microsoft.EntityFrameworkCore;
using StudySync.Data;
using StudySync.Models;

namespace StudySync.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }


         public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }


        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null)
            {
                throw new KeyNotFoundException($"Task with id {id} not found.");
            }
            return task;
        }
       
        public async Task AddTaskAsync(TaskItem task)
        {



            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }



        public async Task<IEnumerable<TaskItem>> GetIncompleteTasksAsync()
        {
            // LINQ query using method syntax:
            return await _context.Tasks
                .Where(t => !t.IsCompleted)       // Filter: select tasks that are not complete.
                .OrderBy(t => t.DueDate)          // Sort: order by due date.
                .ToListAsync();                 // Execute the query asynchronously.
        }

    }

}

