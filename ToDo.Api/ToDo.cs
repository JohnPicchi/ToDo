using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Api
{
  public class ToDo
  {
    public string Title { get; set; }

    public string Description { get; set; }

    public int Priority { get; set; }

    public DateTime DateCreatedUtc { get; set; }

    public DateTime DateUpdatedUtc { get; set; }
  }
}
