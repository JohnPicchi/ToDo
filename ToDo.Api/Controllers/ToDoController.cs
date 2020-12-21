using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Dtos;

namespace ToDo.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ToDoController : ControllerBase
  {
    private readonly ToDoDbContext toDoDbContext;
    
    public ToDoController(ToDoDbContext toDoDbContext)
    {
      this.toDoDbContext = toDoDbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<ToDoDto>> Get()
    {
      var toDos = await toDoDbContext.ToDos
        .ToListAsync();

      return toDos
        .Select(t => new ToDoDto(t))
        .ToList();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      var toDo = await toDoDbContext.ToDos
        .FirstOrDefaultAsync(t => t.Id == id);

      if (toDo == null)
        return NotFound(new {Message = "ToDo not found."});

      return Ok(new ToDoDto(toDo));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ToDoDto toDoDto)
    {
      var data = Data.ToDo.Create(toDoDto);
      
      var result = await toDoDbContext.ToDos.AddAsync(data);
      
      await toDoDbContext.SaveChangesAsync();
      
      var toDo = new ToDoDto(result.Entity);
      
      return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, ToDoDto toDo)
    {
      var data = await toDoDbContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);

      if (data == null)
        return NotFound(new { Message = "ToDo not found."});
      
      data.Update(toDo);
      
      await toDoDbContext.SaveChangesAsync();

      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var data = await toDoDbContext.ToDos
        .SingleOrDefaultAsync(t => t.Id == id);
      
      if (data == null)
        return NotFound(new { Message = "ToDo not found." });

      toDoDbContext.ToDos.Remove(data);
      
      await toDoDbContext.SaveChangesAsync();

      return NoContent();
    }
  }
}