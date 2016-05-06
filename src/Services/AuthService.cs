using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat.src.Services
{
    public class AuthService
    {
        WebService webService = new WebService();

        protected string Username;
        protected string Password;

        protected Dictionary<String, String> getLoginData()
        {
            Dictionary<string, string> loginData = new Dictionary<string, string>()
            {
                { "form_sent", "1" },
                { "referer", "" },
                { "next", "" },
                { "remember", "1" },
                { "username", this.Username },
                { "password", this.Password },
                { "passwordfake", "Password" }
            };

            return loginData;
        }

        protected Dictionary<String, String> getAuthenticationHeaders()
        {
            return new Dictionary<string, string>();
        }

        protected string getAuthenticationUrl()
        {
            return "http://tinychat.com/login";
        }

        public bool login(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

            string response = webService.post(this.getAuthenticationUrl(), this.getLoginData());

            return response == "";
        }


    }
}
