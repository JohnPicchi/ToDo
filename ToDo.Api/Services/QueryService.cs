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
  public interface IQueryService
  {
    Task<IEnumerable<ToDoDto>> GetAllAsync();
    Task<ToDoDto> GetAsync(Guid id);
  }

  internal class QueryService : IQueryService
  {
    private readonly ToDoContext toDoContext;
    
    public QueryService(ToDoContext toDoContext)
    {
      this.toDoContext = toDoContext;
    }
    
    public async Task<IEnumerable<ToDoDto>> GetAllAsync()
    {
      var toDos = await toDoContext.ToDos
        .ToListAsync();

      return toDos
        .Select(t => new ToDoDto(t))
        .ToList();
    }

    public async Task<ToDoDto> GetAsync(Guid id)
    {
      var toDo = await toDoContext.ToDos
        .FirstOrDefaultAsync(t => t.Id == id);

      if (toDo == null)
        throw HttpResponseException.NotFound(new { Message = "ToDo Id not found." });

      return new ToDoDto(toDo);
    }
  }
}
