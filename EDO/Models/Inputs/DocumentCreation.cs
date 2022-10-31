using System;
using System.Collections.Generic;

namespace EDO.Models.Inputs
{
    public class DocumentCreation
    {
        public DocumentCreation()
        {

        }

        public string Title { get; set; } = null!;
        public Guid Type { get; set; }
        public string Recipient { get; set; } = null!;
    }
}
