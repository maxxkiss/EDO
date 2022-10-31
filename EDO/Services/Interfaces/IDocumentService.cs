using EDO.Models;
using EDO.Models.Inputs;

namespace EDO.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> GetDocument(Guid documentId);
        Task<Guid> CreateDocument(Guid userId, DocumentCreation documentCreation);
    }
}