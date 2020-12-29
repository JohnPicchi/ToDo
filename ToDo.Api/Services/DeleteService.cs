using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Repositories;

namespace ToDo.Api.Services
{
  public interface IDeleteService
  {
    Task DeleteAsync(Guid id);
  }
  
  internal class DeleteService : IDeleteService
  {
    private readonly IToDoRepository toDoRepository;
    
    public DeleteService(IToDoRepository toDoRepository)
    {
      this.toDoRepository = toDoRepository;
    }
    
    public async Task DeleteAsync(Guid id)
    {
      await toDoRepository.DeleteAsync(id);
    }
  }
}
