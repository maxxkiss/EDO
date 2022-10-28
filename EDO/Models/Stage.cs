using System;
using System.Collections.Generic;

namespace EDO.Models
{
    public partial class Stage
    {
        public Stage()
        {
            DocumentStages = new HashSet<DocumentStage>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DocumentStage> DocumentStages { get; set; }
    }
}
