using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Infrastructure
{
  public class ToDoContext : DbContext
  {
    public ToDoContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Models.ToDo> ToDos { get; set; }
  }
}