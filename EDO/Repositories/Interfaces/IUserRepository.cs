using EDO.Models;
using EDO.Models.Inputs;

namespace EDO.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateUser(UserRegistration userRegistration);
        Task UpdateUser(Guid userGuid, UserRegistration userRegistration);
        Task<bool> IsLoginUsed(string login);
        Task<User> FindUserById(Guid userGuid);
    }
}