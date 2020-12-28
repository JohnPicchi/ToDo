using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Api.Data
{
  public class ToDoContext : DbContext
  {
    public ToDoContext(DbContextOptions options) : base(options)
    {
      
    }

    public DbSet<ToDo> ToDos { get; set; }
  }
}