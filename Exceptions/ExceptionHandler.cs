using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization.Json;

namespace WebApiMvc.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            //Serializa Json
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(ex.GetType());
            serializer.WriteObject(stream, ex.Message);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}