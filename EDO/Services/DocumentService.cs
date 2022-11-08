using EDO.Models;
using EDO.Models.Inputs;
using EDO.Repositories;
using EDO.Repositories.Interfaces;
using EDO.Repository;
using EDO.Services;
using EDO.Services.Interfaces;

namespace EDO.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<Document> GetDocument(Guid documentId)
        {
            return await _documentRepository.GetDocumentById(documentId);
        }

        public async Task<Guid> CreateDocument(Guid userId, DocumentCreation documentCreation)
        {
            var recipient = await _documentRepository.FindRecipientById(documentCreation.RecipientId);
            var newDocument = new Document(
                   documentCreation.Title,
                   documentCreation.Type,
                   userId,
                   recipient.Id
            );
            return await _documentRepository.CreateDocument(newDocument);
        }
    }
}