using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Extentions
{
    public class HeaderLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public HeaderLoggingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var headers = context.Request.Headers; //"Host"

            StringValues hostValue;

            var isHostValueExists = headers.TryGetValue("Host", out hostValue);

            if (isHostValueExists)
            {
                _logger.Information("Performed request: {@model}", new { host = hostValue.ToString(), method = context.Request.Method });
            }

            await _next(context);
        }
    }
}
