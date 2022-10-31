using EDO.Models;
using EDO.Models.Inputs;
using EDO.Services;
using EDO.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<Document>> GetDocument(Guid documentId)
        {
            var document = await _documentService.GetDocument(documentId);
            if (document is null)
                return NotFound("Document not found");
            return Ok(document);
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<ActionResult<Guid>> CreateDocument([FromRoute] Guid userId, DocumentCreation documentCreation)
        {
            return Ok(await _documentService.CreateDocument(userId, documentCreation));
        }
    }

}
