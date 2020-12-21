using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;

namespace ToDo.Api.Services
{
  internal interface IDeleteService
  {
    Task Delete(Guid id);
  }
  
  internal class DeleteService : IDeleteService
  {
    private readonly ToDoDbContext toDoDbContext;
    
    public DeleteService(ToDoDbContext toDoDbContext)
    {
      this.toDoDbContext = toDoDbContext;
    }
    
    public async Task Delete(Guid id)
    {
      var data = await toDoDbContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);
      
      toDoDbContext.ToDos.Remove(data);
      
      await toDoDbContext.SaveChangesAsync();
    }
  }
}
