using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToDo.Api.Dtos;

namespace ToDo.Api.Data
{
  public class ToDo
  {
    public static ToDo Create(ToDoDto toDo)
    {
      return new ToDo
      {
        Id = Guid.NewGuid(),
        Title = toDo.Title,
        Description = toDo.Description,
        Position = toDo.Position,
        IsCompleted = toDo.IsCompleted,
        DateCreatedUtc = DateTime.UtcNow
      };
    }

    public void Update(ToDoDto toDo)
    {
      Title = toDo.Title;
      Description = toDo.Description;
      Position = toDo.Position;
      IsCompleted = toDo.IsCompleted;
      DateUpdatedUtc = DateTime.UtcNow;
    }
    
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public uint Position { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime DateCreatedUtc { get; set; }

    public DateTime? DateUpdatedUtc { get; set; }
  }
}