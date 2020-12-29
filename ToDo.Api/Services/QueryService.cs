using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Dtos;
using ToDo.Repositories;


namespace ToDo.Api.Services
{
  public interface IQueryService
  {
    Task<IEnumerable<ToDoDto>> GetAllAsync();
    Task<ToDoDto> GetAsync(Guid id);
  }

  internal class QueryService : IQueryService
  {
    private readonly IToDoRepository toDoRepository;
    public QueryService(IToDoRepository toDoRepository)
    {
      this.toDoRepository = toDoRepository;
    }
    
    public async Task<IEnumerable<ToDoDto>> GetAllAsync()
    {
      var toDos = await toDoRepository.GetAllAsync();
      
      return toDos
        .Select(t => new ToDoDto(t))
        .ToList();
    }

    public async Task<ToDoDto> GetAsync(Guid id)
    {
      var toDo = await toDoRepository.GetAsync(id);
      
      return new ToDoDto(toDo);
    }
  }
}
