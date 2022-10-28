using System;
using System.Collections.Generic;

namespace EDO.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public Guid Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; }
    }
}
