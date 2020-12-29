using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Dtos;
using ToDo.Api.Extensions;
using ToDo.Repositories;

namespace ToDo.Api.Services
{
  public interface ICreateService
  {
    Task<ToDoDto> CreateAsync(ToDoDto toDo);
  }
  
  internal class CreateService : ICreateService
  {
    private readonly IToDoRepository toDoRepository;
    
    public CreateService(IToDoRepository toDoRepository)
    {
      this.toDoRepository = toDoRepository;
    }
    
    public async Task<ToDoDto> CreateAsync(ToDoDto dto)
    {
      var domain = dto.ToDomainModel();

      var result = await toDoRepository.CreateAsync(domain);

      return new ToDoDto(result);
    }
  }
}