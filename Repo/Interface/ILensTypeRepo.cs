﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface ILensTypeRepo
    {
        List<LensType> GetLensType();
    }
}
