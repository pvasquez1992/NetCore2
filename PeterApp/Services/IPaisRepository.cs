﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterApp.Services
{
    public interface IPaisRepository
    {
        IList<string> GetPaises();
    }
}
