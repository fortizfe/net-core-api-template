using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using ApiTemplate.Api.Dtos.Generic;
using ApiTemplate.Core.Business.Extensions.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiTemplate.Api.ApiConfig
{
    public static class ErrorsConfig
    {
        #region Internal Methods

        public static IActionResult CustomizeInvalidModelErrors(ActionContext actionContext)
        {
            var response = new ResponseDto<object>() { Succeeded = false, Errors = new List<string>() };

            foreach (var invalidProp in actionContext.ModelState)
            {
                foreach (var error in invalidProp.Value.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }

            return new BadRequestObjectResult(response);
        }

        #endregion Internal Methods
    }

    public class ErrorHandlingMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate next;

        #endregion Private Fields

        #region Public Constructors

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Log.Fatal($"{ex.GetaAllMessages()}");
                await HandleExceptionAsync(context, ex);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = exception switch
            {
                DisabledWorkerException _ => HttpStatusCode.Forbidden,
                EntityNotFoundException _ => HttpStatusCode.NotFound,
                InvalidParameterFormatException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };

            var response = new ResponseDto<object>
            {
                Succeeded = false,
                Errors = new List<string>() { exception.GetaAllMessages() }
            };

            var result = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

        #endregion Private Methods
    }
}