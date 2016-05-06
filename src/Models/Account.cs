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

    [Serializable]
    public class Account
    {
        public string Username;
        public string Password;

        [NonSerialized]
        public AuthenticationStatus AuthStatus = AuthenticationStatus.NotAuthenticated;


        public override string ToString()
        {
            return this.Username;
        }
    }
}
