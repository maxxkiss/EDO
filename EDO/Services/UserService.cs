using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EDO.Repositories;
using EDO.Models.Inputs;
using EDO.Models;
using EDO.Services.Interfaces;
using EDO.Repositories.Interfaces;

namespace EDO.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> RegisterUser(UserRegistration userRegistration)
        {
            if (await _userRepository.IsLoginUsed(userRegistration.Login))
                throw new Exception("This login is already used");
            return await _userRepository.CreateUser(userRegistration);
        }

        public async Task UpdateUser(Guid userGuid, UserRegistration userRegistration)
        {
            var currentUser = await _userRepository.FindUserById(userGuid);
            if (currentUser.Login != userRegistration.Login)
            {
                if (await _userRepository.IsLoginUsed(userRegistration.Login))
                    throw new Exception("This login is already used");
            }
            await _userRepository.UpdateUser(currentUser, userRegistration);
        }

        public async Task<bool> AuthoriseUser(string login, string password)
        {
            if (!await _userRepository.IsLoginUsed(login))
                throw new Exception("Login not found");
            var user = await _userRepository.FindUserByLogin(login);
            if (user.Password == password)
                return true;
            return false;
        }
    }
}
