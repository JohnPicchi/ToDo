using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IEnumerable<ToDo>> Get()
    {
      return null;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
      return null;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
      return null;
    }

    [HttpPut]
    public async Task<IActionResult> Edit()
    {
      return null;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      return null;
    }
  }
}