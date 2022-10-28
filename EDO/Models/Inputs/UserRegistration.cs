using System;
using System.Collections.Generic;

namespace EDO.Models.Inputs
{
    public class UserRegistration
    {
        public UserRegistration(string firstName, string secondName, string? thirdName, string login, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            Login = login;
            Password = password;
        }

        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string? ThirdName { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
