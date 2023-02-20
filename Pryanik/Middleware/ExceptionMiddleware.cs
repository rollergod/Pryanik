using Pryanik.Entities;
using Pryanik.Entities.Exceptions;

namespace Pryanik.Middleware
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsync(new ErrorDetails()
                { 
                    Message = ex.Message, 
                    StatusCode = context.Response.StatusCode 
                }.ToString());
                   
            }
        }
    }
}
