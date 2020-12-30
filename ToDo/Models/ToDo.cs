using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
  public class ToDo
  {
    public ToDo() {  }

    public static ToDo Create(ToDo toDo)
    {
      return new ToDo
      {
        Title = toDo.Title,
        Description = toDo.Description,
        Position = toDo.Position,
        IsCompleted = toDo.IsCompleted,
        DateCreatedUtc = DateTime.UtcNow,
      };
    }
    
    public void Update(ToDo toDo)
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