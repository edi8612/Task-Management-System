using Microsoft.AspNetCore.Mvc;
using Moq;
using StudySync.Controllers;
using StudySync.Dtos;
using StudySync.Services;

namespace MyProject.Tests
{
    public class TaskItemControllerTest
    {
       private readonly Mock<ITaskItemService> _taskItemServiceMock;    
       private readonly TaskItemController _controller;

        public TaskItemControllerTest()
        {
            _taskItemServiceMock = new Mock<ITaskItemService>();
            _controller = new TaskItemController(_taskItemServiceMock.Object);
        }


        [Fact]
        public async Task GetAllTasks_ReturnsOkResult_WithListOfTasks()
        {
            // Arrange
            var tasks = new List<TaskItemDTO>
            {
                new TaskItemDTO { Id = 1, Title = "Task 1",Description = "Description 1",Priority = "High" },
                new TaskItemDTO { Id = 2, Title = "Task 2",Description = "Description 2",Priority = "Medium"}
            };
            _taskItemServiceMock.Setup(service => service.GetAllTasksAsync())
                .ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetTasks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTasks = Assert.IsAssignableFrom<IEnumerable<TaskItemDTO>>(okResult.Value);
            Assert.Equal(2, returnedTasks.Count());
        }





    }
}
