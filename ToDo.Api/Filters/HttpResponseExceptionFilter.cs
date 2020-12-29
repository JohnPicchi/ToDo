using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Infrastructure.Exceptions;


namespace ToDo.Api.Filters
{
  public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
  {
    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is NotFoundException exception)
      {
        context.Result = new ObjectResult(new { Message = $"Unable to find todo with id of {exception.Id}" })
        {
          StatusCode = StatusCodes.Status404NotFound
        };
        
        context.ExceptionHandled = true;
      }
    }

    public int Order { get; } = Int32.MaxValue - 10;
  }
}