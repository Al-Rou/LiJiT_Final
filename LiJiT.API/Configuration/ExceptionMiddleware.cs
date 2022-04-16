using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LiJiT.API.Configuration
{
  
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            public ExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
            }

            private Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = -1;

                return context.Response.WriteAsync(new ErrorDetails()
                {
                    ResponseCode = context.Response.StatusCode.ToString(),
                    Description = "Internal Error"
                }.ToString());
            }
        }
    }

