using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Api.Exceptions;

namespace ToDo.Api.Filters
{
  public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is HttpResponseException exception)
      {
        context.Result = new ObjectResult(exception.Value)
        {
          StatusCode = exception.Status
        };
        
        context.ExceptionHandled = true;
      }
    }

    public int Order { get; } = Int32.MaxValue - 10;
  }
}