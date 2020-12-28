using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Exceptions;

namespace ToDo.Api.Services
{
  public interface IDeleteService
  {
    Task DeleteAsync(Guid id);
  }
  
  internal class DeleteService : IDeleteService
  {
    private readonly ToDoContext toDoContext;
    
    public DeleteService(ToDoContext toDoContext)
    {
      this.toDoContext = toDoContext;
    }
    
    public async Task DeleteAsync(Guid id)
    {
      var data = await toDoContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);
      
      if(data == null)
        throw HttpResponseException.NotFound(new { Message = "ToDo Id not found." });
      
      toDoContext.ToDos.Remove(data);
      
      await toDoContext.SaveChangesAsync();
    }
  }
}
