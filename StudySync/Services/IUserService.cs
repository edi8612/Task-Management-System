using StudySync.Models;

namespace StudySync.Services
{
    public interface IUserService
    {

        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User?> GetUserByIdAsync(int id);

        public Task AddUserAsync(User user);

        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int id);

        public Task<IEnumerable<User>> GetUsersWithPendingTasksAsync();
    }
}
