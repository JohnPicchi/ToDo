﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Exceptions
{
  public class NotFoundException : Exception
  {
    public Guid Id { get; set; }
  }
}