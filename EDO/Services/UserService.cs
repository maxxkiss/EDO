using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EDO.Repositories;
using EDO.Models.Inputs;

namespace EDO.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> RegistryUser(UserRegistration userRegistration)
        {
            
        }

    }
}
