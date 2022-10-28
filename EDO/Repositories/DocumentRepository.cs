using EDO.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EDO.Repository
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DocumentRepository
    {
        private readonly EDOContext _context;

        public DocumentRepository(EDOContext context)
        {
            _context = context;
        }


    }
}