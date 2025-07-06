using OpenTelemetry.Trace;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Tourism.Domain.Helpers;
using Tourism.Shared.Models;

namespace Tourism.Presentation.Api.Middleware;

public class ApiMiddleware
{
    public static Func<HttpContext, Func<Task>, Task> HandleException => async (context, next) =>
    {
        var logger = context.RequestServices.GetService<ILogger>();
        try
        {
            await next();
        }
        catch (Exception e)
        {
            var tracerProvider = context.RequestServices.GetService<TracerProvider>();
            var tracer = tracerProvider?.GetTracer(Assembly.GetExecutingAssembly().FullName, "1.0.0");
            using var span = tracer?.StartActiveSpan("exception");
            span?.SetAttribute("exception", e.Message);
            span?.RecordException(e);
            logger?.LogError(e, e.Message);
            span?.End();
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            await JsonSerializer.SerializeAsync(
                context.Response.Body,
                new BaseResponse<string?>(null, "Sorry! Something went wrong.", ReturnCode.EXCEPTION, new List<Error>() { new Error(ReturnCode.EXCEPTION, e.Message) }),
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
        }
    };
}
