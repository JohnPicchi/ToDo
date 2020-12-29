using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Repositories
{
  public interface IToDoRepository
  {
    Task<Models.ToDo> CreateAsync(Models.ToDo toDo);
    
    Task DeleteAsync(Guid id);

    Task<IEnumerable<Models.ToDo>> GetAllAsync();

    Task<Models.ToDo> GetAsync(Guid id);

    Task UpdateAsync(Models.ToDo toDo);
  }
}