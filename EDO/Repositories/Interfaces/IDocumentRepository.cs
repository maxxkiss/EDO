using EDO.Models.Inputs;
using EDO.Models;

namespace EDO.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Document> GetDocumentById(Guid documentId);
        Task<Guid> CreateDocument(Document documentId);
        Task<User> FindRecipientById(Guid recipientLogin);
    } 
}