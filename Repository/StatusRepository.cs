﻿using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
  public  class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
      public StatusRepository(BaseContext repositoryContext)
          : base(repositoryContext)
      {
      }
    }
}
