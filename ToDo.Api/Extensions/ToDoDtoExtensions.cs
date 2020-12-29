using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Api.Dtos;

namespace ToDo.Api.Extensions
{
  public static class ToDoDtoExtensions
  {
    public static Models.ToDo ToDomainModel(this ToDoDto dto)
    {
      return new Models.ToDo
      {   
        Id = dto.Id,
        Title = dto.Title,
        Description = dto.Description,
        Position = dto.Position,
        IsCompleted = dto.IsCompleted,
        DateCreatedUtc = dto.DateCreatedUtc,
        DateUpdatedUtc = dto.DateUpdatedUtc
      };
    }
  }
}
