using EDO.Models.Inputs;

namespace EDO.Services.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterUser(UserRegistration userRegistration);
        Task UpdateUser(Guid userGuid, UserRegistration userRegistration);
    }
}