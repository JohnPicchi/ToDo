using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Exceptions;
using ToDo.Repositories;

namespace ToDo.Infrastructure.Repositories
{
  public class ToDoRepository : IToDoRepository
  {
    private readonly ToDoContext toDoContext;
    
    public ToDoRepository(ToDoContext toDoContext)
    {
      this.toDoContext = toDoContext;
    }

    public async Task<Models.ToDo> CreateAsync(Models.ToDo toDo)
    {
      var data = Models.ToDo.Create(toDo);
      
      var result = await toDoContext.ToDos.AddAsync(data);

      await toDoContext.SaveChangesAsync();

      return result.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
      var data = await toDoContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);

      if (data == null)
        throw new NotFoundException { Id = id };

      toDoContext.ToDos.Remove(data);

      await toDoContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Models.ToDo>> GetAllAsync()
    {
      var toDos = await toDoContext.ToDos
        .ToListAsync();

      return toDos;
    }

    public async Task<Models.ToDo> GetAsync(Guid id)
    {
      var toDo = await toDoContext.ToDos
        .FirstOrDefaultAsync(t => t.Id == id);

      if (toDo == null)
        throw new NotFoundException { Id = id };

      return toDo;
    }

    public async Task UpdateAsync(Models.ToDo toDo)
    {
      var data = await toDoContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == toDo.Id);

      if (data == null)
        throw new NotFoundException { Id = toDo.Id };

      data.Update(toDo);
      
      await toDoContext.SaveChangesAsync();
    }
  }
}