using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Data;
using ToDo.Api.Dtos;

namespace ToDo.Api.Services
{
  internal interface ICreateService
  {
    Task<ToDoDto> Create(ToDoDto toDo);
  }
  
  internal class CreateService : ICreateService
  {
    private readonly ToDoDbContext toDoDbContext;
    
    public CreateService(ToDoDbContext toDoDbContext)
    {
      this.toDoDbContext = toDoDbContext;
    }
    
    public async Task<ToDoDto> Create(ToDoDto toDo)
    {
      var data = Data.ToDo.Create(toDo);

      var result = await toDoDbContext.ToDos.AddAsync(data);

      await toDoDbContext.SaveChangesAsync();

      return new ToDoDto(result.Entity);
    }
  }
}