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
    private readonly DatabaseContext dbContext;
    
    public ToDoRepository(DatabaseContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public async Task<Models.ToDo> CreateAsync(Models.ToDo toDo)
    {
      var data = Models.ToDo.Create(toDo);
      
      var result = await dbContext.ToDos.AddAsync(data);

      return result.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
      var data = await dbContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);

      if (data == null)
        throw new NotFoundException { Id = id };

      dbContext.ToDos.Remove(data);
    }

    public async Task<IEnumerable<Models.ToDo>> GetAllAsync()
    {
      var toDos = await dbContext.ToDos
        .ToListAsync();

      return toDos;
    }

    public async Task<Models.ToDo> GetAsync(Guid id)
    {
      var toDo = await dbContext.ToDos
        .FirstOrDefaultAsync(t => t.Id == id);

      if (toDo == null)
        throw new NotFoundException { Id = id };

      return toDo;
    }

    public async Task UpdateAsync(Models.ToDo toDo)
    {
      var data = await dbContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == toDo.Id);

      if (data == null)
        throw new NotFoundException { Id = toDo.Id };

      data.Update(toDo);
    }
  }
}