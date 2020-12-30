using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Infrastructure;

namespace ToDo.Api.Filters
{
  public class DatabaseContextTransactionFilter : IAsyncActionFilter
  {
    private readonly DatabaseContext dbContext;

    public DatabaseContextTransactionFilter(DatabaseContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      try
      {
        await dbContext.BeginTransactionAsync();

        await next();

        await dbContext.CommitTransactionAsync();
      }
      catch (Exception e)
      { 
        await dbContext.RollBackTransactionAsync();
      }
    }
  }
}
