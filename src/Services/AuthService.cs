using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyChat.src.Services
{
    public class AuthService
    {
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
            Dictionary<string, string> AuthenticationHeaders = new Dictionary<string, string>()
            {
                { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" },
                { "Origin", "http://tinychat.com" },
                { "User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.85 Safari/537.36 OPR/32.0.1948.25" },
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "Referer", "http://tinychat.com/login?frame=true" },
                { "Accept-Encoding", "gzip, deflate, lzma" },
                { "Accept-Language", "en-US,en;q=0.8" }
            };

            return AuthenticationHeaders;
        }

        protected string getAuthenticationUrl()
        {
            return "http://tinychat.com/login";
        }

        public bool login(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

            return true;
        }


    }
}
