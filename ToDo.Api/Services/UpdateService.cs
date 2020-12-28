using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Dtos;
using ToDo.Api.Exceptions;

namespace ToDo.Api.Services
{
  public interface IUpdateService
  {
    Task UpdateAsync(ToDoDto toDo);
  }
  
  internal class UpdateService : IUpdateService
  {
    private readonly ToDoContext toDoContext;

    public UpdateService(ToDoContext toDoContext)
    {
      this.toDoContext = toDoContext;
    }
    
    public async Task UpdateAsync(ToDoDto toDo)
    {
      var data = await toDoContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == toDo.Id);

      if (data == null)
        throw HttpResponseException.NotFound(new { Message = "ToDo Id not found." });
      
      data.Update(toDo);

      await toDoContext.SaveChangesAsync();

    }
  }
}