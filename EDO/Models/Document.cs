using System;
using System.Collections.Generic;

namespace EDO.Models
{
    public partial class Document
    {
        public Document()
        {
            DocumentStages = new HashSet<DocumentStage>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public Guid Type { get; set; }
        public Guid Author { get; set; }
        public Guid Recipient { get; set; }

        public virtual User AuthorNavigation { get; set; } = null!;
        public virtual User RecipientNavigation { get; set; } = null!;
        public virtual DocumentType TypeNavigation { get; set; } = null!;
        public virtual ICollection<DocumentStage> DocumentStages { get; set; }
    }
}
