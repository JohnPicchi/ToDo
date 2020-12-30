using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Api.Dtos
{
  public class ToDoDto 
  {
    public ToDoDto()
    {
      
    }
    
    public ToDoDto(Models.ToDo data)
    {
      Id = data.Id;
      Title = data.Title;
      Description = data.Description;
      Position = data.Position;
      IsCompleted = data.IsCompleted;
      DateCreatedUtc = data.DateCreatedUtc;
      DateUpdatedUtc = data.DateUpdatedUtc;
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
