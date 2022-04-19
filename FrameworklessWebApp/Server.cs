using System;
using System.Net;

namespace FrameworklessWebApp
{
    public class Server
    {
       

        public void ServerStart()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            server.Start();
            while (true)
            {
                var context = server.GetContext(); // Gets the request
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var buffer = System.Text.Encoding.UTF8.GetBytes("Hello, so this puts stuff here ");
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length); // forces send of response
            }

            server.Stop(); // never reached...

        }
    }
}
