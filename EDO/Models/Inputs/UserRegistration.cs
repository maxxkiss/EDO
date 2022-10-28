using System;
using System.Collections.Generic;

namespace EDO.Models.Inputs
{
    public class UserRegistration
    {
        public UserRegistration()
        {
            
        }

        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
