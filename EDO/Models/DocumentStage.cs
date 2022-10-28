using System;
using System.Collections.Generic;

namespace EDO.Models
{
    public partial class DocumentStage
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid StageId { get; set; }
        public Guid VerifierId { get; set; }
        public DateTime VerifyDate { get; set; }

        public virtual Document Document { get; set; } = null!;
        public virtual Stage Stage { get; set; } = null!;
        public virtual User Verifier { get; set; } = null!;
    }
}
