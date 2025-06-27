using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LogCloud.Middleware
{
    public class RequestLoggingMiddleware : IMiddleware,ITransientDependency
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.Request;
            _logger.LogInformation($"Request started: {request.Method} {request.Path}");

            try
            {
                await next(context);
                _logger.LogInformation($"Request finished: {request.Method} {request.Path} with status {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Request failed: {request.Method} {request.Path}");
                throw;
            }
        }
    }

}
