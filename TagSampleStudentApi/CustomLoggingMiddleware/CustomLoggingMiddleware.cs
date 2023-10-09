using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;



namespace TagSampleStudentApi.CustomLoggingMiddleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the request
            LogRequest(context);

            // Capture the response
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                // Log the response
                await LogResponse(context, responseBody);
            }
        }

        private void LogRequest(HttpContext context)
        {
            if (_logger != null)
            {
                _logger.LogInformation("Request {RequestMethod} {RequestPath}", context.Request.Method, context.Request.Path);

            }
        }

        private async Task LogResponse(HttpContext context, MemoryStream responseBody)
        {
            responseBody.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(responseBody).ReadToEndAsync();
            _logger.LogInformation("Response {StatusCode} {Response}", context.Response.StatusCode, response);
        }
    }
}
