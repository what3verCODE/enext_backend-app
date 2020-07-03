﻿using System;
using System.Collections.Generic;
using Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiServer.Filters
{
    public class ApiFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiFilter()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(RefreshTokenException), HandleRefreshTokenException },
                { typeof(AuthenticationException), HandleAuthenticationException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
            
            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occured while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };
            
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
            if (context.Exception is ValidationException exception)
            {
                var details = new ValidationProblemDetails(exception.Errors)
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                };
                
                context.Result = new BadRequestObjectResult(details);
                context.ExceptionHandled = true;
            }
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException exception)
            {
                var details = new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Title = "The specified resource was not found.",
                    Detail = exception.Message
                };

                context.Result = new NotFoundObjectResult(details);
                context.ExceptionHandled = true;
            }
        }

        private void HandleRefreshTokenException(ExceptionContext context)
        {
            if (context.Exception is RefreshTokenException exception)
            {
                var details = new ProblemDetails
                {
                    Detail = exception.Message
                };
                
                context.Result = new BadRequestObjectResult(details);
                context.ExceptionHandled = true;
            }
        }

        private void HandleAuthenticationException(ExceptionContext context)
        {
            if (context.Exception is AuthenticationException exception)
            {
                var details = new ProblemDetails
                {
                    Detail = exception.Message
                };
                
                context.Result = new BadRequestObjectResult(details);
                context.ExceptionHandled = true;
            }
        }
    }
}