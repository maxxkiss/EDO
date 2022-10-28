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
        public User(string firstName, string secondName, string? thirdName, string login, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            Login = login;
            Password = password;
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
