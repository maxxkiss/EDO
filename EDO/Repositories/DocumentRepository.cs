using EDO.Models;
using EDO.Models.Inputs;
using EDO.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EDO.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly EDOContext _context;

        public DocumentRepository(EDOContext context)
        {
            _context = context;
        }

        public async Task<Document> GetDocumentById(Guid documentId)
        {
            var document = await _context.Documents.SingleOrDefaultAsync(u => u.Id == documentId);
            if (document is null)
                throw new Exception("Document not found");
            return document;
        }

        public async Task<Guid> CreateDocument(Document newDocument)
        {
            await _context.Documents.AddAsync(newDocument);
            await _context.SaveChangesAsync();
            return newDocument.Id;
        }

        public async Task<User> FindRecipientById(Guid recipientId)
        {
            var recipient = await _context.Users.SingleOrDefaultAsync(u => u.Id == recipientId);
            if (recipient is null)
                throw new Exception("Recipient not found");
            return recipient;
        }
    }
}