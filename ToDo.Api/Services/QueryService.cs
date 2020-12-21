using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Dtos;

namespace ToDo.Api.Services
{
  internal interface IQueryService
  {
    Task<IEnumerable<ToDoDto>> Get();
    Task<ToDoDto> Get(Guid id);
  }

  internal class QueryService : IQueryService
  {
    private readonly ToDoDbContext toDoDbContext;
    
    public QueryService(ToDoDbContext toDoDbContext)
    {
      this.toDoDbContext = toDoDbContext;
    }
    
    public async Task<IEnumerable<ToDoDto>> Get()
    {
      var toDos = await toDoDbContext.ToDos
        .ToListAsync();

      return toDos
        .Select(t => new ToDoDto(t))
        .ToList();
    }

    public async Task<ToDoDto> Get(Guid id)
    {
      var toDo = await toDoDbContext.ToDos
        .FirstOrDefaultAsync(t => t.Id == id);

      return toDo != null
        ? new ToDoDto(toDo)
        : null;
    }
  }
}
