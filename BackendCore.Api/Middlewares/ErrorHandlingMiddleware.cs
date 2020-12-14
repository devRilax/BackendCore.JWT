using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackendCore.Common.Exceptions;
using System.Linq;
using Serilog;

namespace BackendCore.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        public readonly RequestDelegate _next;
        private ILogger logger = Log.ForContext<ErrorHandlingMiddleware>();

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionResponse response = null;

            if (exception is BusinessException)
            {
                var _ex = exception as BusinessException;
                response = new ExceptionResponse(exception.Message);

                if (_ex.Messages.Any())
                    response.Messages.AddRange(_ex.Messages);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exception is NotFoundException)
            {
                var _ex = exception as NotFoundException;

                response = new ExceptionResponse(exception.Message);
                response.Detail = "Uno o mas recursos no fueron encontrados";

                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            } 
            else if (exception is AuthException)
            {
                var _ex = exception as AuthException;

                response = new ExceptionResponse(_ex.Message);
                response.Detail = "No cuenta con autorizacion para realizar esta acción";

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                response = new ExceptionResponse("Ha ocurrido un error desconocido, para mayor información contacte al administrador");
                response.Detail = exception.Message;

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(response);

            //falta confgigurar bien el manejo de logs
            logger.Error(exception, "{@Log}, ", new { result });

            return  context.Response.WriteAsync(result);
        }
    }
}
