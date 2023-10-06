using Microsoft.AspNetCore.Http;
using SelfieAWookie.Core.Selfies.Infrastructure.Logger;

namespace SelfieAWookie.API.UI.MiddleWare
{
    public class LogRequestMiddleware
    {
        private RequestDelegate _next;
        private readonly ILogger _logger;

        public LogRequestMiddleware( ILogger<LoggerSelfie> logger, RequestDelegate request)
        {
            _logger = logger;
            _next = request;
        }

        public async Task Invoke(HttpContext context)
        {
            this._logger.LogDebug(context.Request.Path.Value);
            await _next.Invoke(context);
        }
    }
}
