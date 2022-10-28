using EDO.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EDO.Repositories
{
    public class UserRepository
    {
        private readonly EDOContext _context;

        public UserRepository(EDOContext context)
        {
            _context = context;
        }
    }
}
