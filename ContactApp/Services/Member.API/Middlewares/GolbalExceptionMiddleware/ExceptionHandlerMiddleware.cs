using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Security.Authentication;

namespace Member.API.Middlewares.GolbalExceptionMiddleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError

            };
            string result = "";
            if (statusCode == (int)HttpStatusCode.BadRequest)
            {
                var errors = ((ValidationException)exception).Errors;

                if (errors != null)
                {
                    result = JsonConvert.SerializeObject(new
                    {
                        StatusCode = statusCode,//errors.Select(e => e.ErrorCode).FirstOrDefault(),
                        ErrorMessage = errors.Select(e => e.ErrorMessage).FirstOrDefault()
                    }); ;
                }
                else
                {
                    result = JsonConvert.SerializeObject(new
                    {
                        StatusCode = statusCode,
                        ErrorMessage = exception.Message
                    });
                }
            }
            else
            {
				result = JsonConvert.SerializeObject(new
				{
					StatusCode = statusCode,
					ErrorMessage = exception.Message
				});
			}
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }

}
