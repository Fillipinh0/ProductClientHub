﻿using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Caommunication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProductClientHubException productClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int)productClientHubException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubException.GetErrors()));
            }
            else
            {
                ThrowUnknowError(context);
            }
        }
        
        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido"));
        }
    
    
    }
}
