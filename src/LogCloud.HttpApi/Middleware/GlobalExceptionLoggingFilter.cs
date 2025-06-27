using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LogCloud.Middleware
{
    public class GlobalExceptionLoggingFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionLoggingFilter> _logger;

        public GlobalExceptionLoggingFilter(ILogger<GlobalExceptionLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled exception occurred while processing request:   {Message} {@Errors} {@Exceptions}", context.Exception.Message, context.Exception.Message, context.Exception);
            // Let ABP handle the response
        }
    }
} 