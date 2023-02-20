using Hafta4.Odev5_6_7.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Hafta4.Odev5_6_7.Middlewares
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication app, ILogger<T> logger)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Setting response type to Json
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    // Getting exception name
                    var exceptionTypeName = contextFeature?.Error.GetType().Name;

                    switch (exceptionTypeName)
                    {
                        case nameof(BookNotExistsException) or
                             nameof(GenreNotExistsException) or
                             nameof(BookToDeleteNotExistsException) or
                             nameof(WrongParameterEnteredForFilterBooksException) or
                             nameof(SearchBooksByTitleException) or
                             nameof(WrongUsernameEnteredException) or
                             nameof(WrongPasswordEnteredException):
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            break;
                        case nameof(MissingLoginKeyException):
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            break;
                        default:
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }

                    logger.LogError(contextFeature?.Error.Message);

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            context.Response.StatusCode,
                            Title = "An error occurred!",
                            contextFeature.Error.Message
                        }));
                    }
                });
            });
        }
    }
}
