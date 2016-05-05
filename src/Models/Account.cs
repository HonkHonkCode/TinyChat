using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat.src.Models
{
    public enum AuthenticationStatus
    {
        NotAuthenticated = 1,
        Authenticated = 2,
        Error = 3
    }

    public class Account
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public AuthenticationStatus AuthStatus { set; get; }
    }
}
