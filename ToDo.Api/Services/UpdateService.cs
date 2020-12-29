using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Dtos;
using ToDo.Api.Extensions;
using ToDo.Repositories;

namespace ToDo.Api.Services
{
  public interface IUpdateService
  {
    Task UpdateAsync(ToDoDto toDo);
  }
  
  internal class UpdateService : IUpdateService
  {
    private readonly IToDoRepository toDoRepository;
    
    public UpdateService(IToDoRepository toDoRepository)
    {
      this.toDoRepository = toDoRepository;
    }
    
    public async Task UpdateAsync(ToDoDto dto)
    { 
      var domain = dto.ToDomainModel();

      await toDoRepository.UpdateAsync(domain);
    }
  }
}