using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ToDo.Api.Exceptions
{
  public class HttpResponseException : Exception
  {
    public static HttpResponseException NotFound(object value)
    {
      return new HttpResponseException
      {
        Status = StatusCodes.Status404NotFound,
        Value = value
      };
    }
    
    public int Status { get; set; } = StatusCodes.Status500InternalServerError;
    
    public object Value { get; set; }
  }
}