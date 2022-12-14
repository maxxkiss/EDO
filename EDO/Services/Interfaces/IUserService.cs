using EDO.Models.Inputs;

namespace EDO.Services.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterUser(UserRegistration userRegistration);
        Task UpdateUser(Guid userId, UserRegistration userRegistration);
        Task<bool> AuthoriseUser(string login, string password);
    }
}