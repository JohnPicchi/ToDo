using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Dtos;
using ToDo.Api.Services;

namespace ToDo.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ToDoController : ControllerBase
  {
    public ToDoController()
    {
      
    }

    [HttpGet]
    public async Task<IEnumerable<ToDoDto>> Get([FromServices] IQueryService queryService)
    {
      var toDos = await queryService.GetAllAsync();
      
      return toDos;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromServices] IQueryService queryService, [FromRoute] Guid id)
    {
      var toDo = await queryService.GetAsync(id);
      
      return Ok(toDo);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] ICreateService createService, ToDoDto toDoDto)
    {
      var toDo = await createService.CreateAsync(toDoDto);
      
      return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit([FromServices] IUpdateService updateService, [FromRoute] Guid id,
      ToDoDto toDoDto)
    {
      toDoDto.Id = id;

      await updateService.UpdateAsync(toDoDto);

      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromServices] IDeleteService deleteService, Guid id)
    {
      await deleteService.DeleteAsync(id);
      
      return NoContent();
    }
  }
}