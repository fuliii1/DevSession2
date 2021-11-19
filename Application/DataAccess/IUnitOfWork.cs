﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    internal interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
