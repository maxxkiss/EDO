using EDO.Models;
using EDO.Models.Inputs;

namespace EDO.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateUser(UserRegistration userRegistration);
        Task UpdateUser(User user, UserRegistration userRegistration);
        Task<bool> IsLoginUsed(string login);
        Task<User> FindUserById(Guid userId);
        Task<User> FindUserByLogin(string login);
    }
}