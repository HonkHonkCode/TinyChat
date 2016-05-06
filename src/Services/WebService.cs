using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace TinyChat.src.Services
{
    public class WebService
    {
        protected Dictionary<string, string> RequestHeaders = new Dictionary<string, string>()
        {
            { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8" },
            { "User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.85 Safari/537.36 OPR/32.0.1948.25" },
            { "Content-Type", "application/x-www-form-urlencoded" },
            { "Accept-Encoding", "gzip, deflate, lzma" },
            { "Accept-Language", "en-US,en;q=0.8" }
        };

        protected CookieContainer Cookies;

        public WebService()
        {
            RequestHeaders = new Dictionary<string, string>();
            Cookies = new CookieContainer();
        }

        public string get(string url)
        {
            HttpWebRequest request = this.buildRequest(url);
            return this.readResponse(request);
        }

        public string post(string url, string body)
        {
            HttpWebRequest request = this.buildRequest(url);
            this.writeRequestData(request, body);
            return this.readResponse(request);
        }


        public string post(string url, Dictionary<string, string> body, string contentType = "application/x-www-form-urlencoded", string referer = "")
        {
            HttpWebRequest request = this.buildRequest(url);
            request.Method = "POST";
            request.ContentType = contentType;
            request.Referer = referer;

            this.writeRequestData(request, this.convertBodyDictToString(body));
            return this.readResponse(request);
        }

        public void setHeader(string key, string value)
        {
            this.RequestHeaders[key] = value;
        }

        public void deleteHeader(string key)
        {
            this.RequestHeaders.Remove(key);
        }

        protected string convertBodyDictToString(Dictionary<string, string> headers)
        {
            List<String> formattedValues = new List<string>();

            foreach (KeyValuePair<String, String> value in headers)
            {
                formattedValues.Add(string.Format("{0}={1}", value.Key, value.Value));
            }

            string postString = string.Join("&", formattedValues);

            return postString;
        }

        // Write the post data to a request
        protected HttpWebRequest writeRequestData(HttpWebRequest request, string body)
        {
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            }
            System.Net.ServicePointManager.Expect100Continue = false;
            return request;
        }

        // Format the request with headers and cookies
        protected HttpWebRequest buildRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers = this.formatHeaders();
            request.CookieContainer = Cookies;
            request.AllowAutoRedirect = false;

            return request;
        }

        // Get response and read the 
        protected string readResponse(HttpWebRequest request)
        {
            return this.readResponseToString(this.getResponse(request));
        }

        protected HttpWebResponse getResponse(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            this.Cookies.Add(response.Cookies);
            return response;
        }

        protected string readResponseToString(HttpWebResponse response)
        {
            string responseString = "";

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }

            return responseString;
        }

        protected WebHeaderCollection formatHeaders()
        {
            WebHeaderCollection headerCollection = new WebHeaderCollection();

            foreach(KeyValuePair<String, String> header in this.RequestHeaders)
            {
                headerCollection[header.Key] = header.Value;
            }

            return headerCollection;
        }
    }
}
