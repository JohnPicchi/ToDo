using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Data;
using ToDo.Api.Dtos;

namespace ToDo.Api.Services
{
  public interface ICreateService
  {
    Task<ToDoDto> CreateAsync(ToDoDto toDo);
  }
  
  internal class CreateService : ICreateService
  {
    private readonly ToDoContext toDoContext;
    
    public CreateService(ToDoContext toDoContext)
    {
      this.toDoContext = toDoContext;
    }
    
    public async Task<ToDoDto> CreateAsync(ToDoDto toDo)
    {
      var data = Data.ToDo.Create(toDo);

      var result = await toDoContext.ToDos.AddAsync(data);

      await toDoContext.SaveChangesAsync();

      return new ToDoDto(result.Entity);
    }
  }
}