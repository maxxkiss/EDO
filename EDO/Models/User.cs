using System;
using System.Collections.Generic;

namespace EDO.Models
{
    public partial class User
    {
        public User()
        {
            DocumentAuthorNavigations = new HashSet<Document>();
            DocumentRecipientNavigations = new HashSet<Document>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual DocumentStage? DocumentStage { get; set; }
        public virtual ICollection<Document> DocumentAuthorNavigations { get; set; }
        public virtual ICollection<Document> DocumentRecipientNavigations { get; set; }
    }
}
