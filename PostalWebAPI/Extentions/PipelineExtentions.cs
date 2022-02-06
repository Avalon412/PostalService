using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using PostalWebAPI.Models;

namespace PostalWebAPI.Extentions
{
    public static class PipelineExtentions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        await context.Response.WriteAsJsonAsync(new ErrorResponse
                        {
                            SessionID = string.Empty,
                            Error = true,
                            Reason = Errors.ExceptionOccured
                        });

                        logger.Error(contextFeature.Error.Message);
                    }
                });
            });
        }

        public static IApplicationBuilder UseHeaderLogging(this IApplicationBuilder builder, ILogger logger)
        {
            return builder.UseMiddleware<HeaderLoggingMiddleware>(logger);
        }
    }
}
