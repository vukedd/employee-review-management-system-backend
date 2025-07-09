using Domain.Enums.User;

namespace Application.Common.Repositories
{
    public interface IUserRepository
    {
        public Task<Domain.Models.Users.User> CreateAsync(Domain.Models.Users.User user);
        public Task<Domain.Models.Users.User?> GetUserByEmail(string email);
        public Task<Domain.Models.Users.User?> GetUserByUsername(string username);
        public Task<Role?> GetRoleByUserId(long id);
        public Task<Domain.Models.Users.User?> GetUserById(long id);
        public Task<IEnumerable<Domain.Models.Users.User>> GetAllUsers();
    }
}
