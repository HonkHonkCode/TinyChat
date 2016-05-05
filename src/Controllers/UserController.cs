using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyChat.src.Models;
using TinyChat.src.Exceptions;
using TinyChat.src.Services;


namespace TinyChat.src.Controllers
{
    public class UserController
    {
        // Authenticate the user via HTTP & hand back the account
        public Account authenticate(string Username, string Password)
        {
            if (Username == null || Password == null)
            {
                throw new ValidationException("Username and Password are required to log in");
            }

            AuthService authService = new AuthService();

            if (authService.login(Username, Password))
            {
                Account returnObject = new Account();
                returnObject.AuthStatus = AuthenticationStatus.Authenticated;
                returnObject.Username = Username;
                returnObject.Password = Password;
                return returnObject;
            }
            else
            {
                throw new AuthException();
            }
        }
    }
}
