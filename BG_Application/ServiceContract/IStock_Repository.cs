﻿using BG_Application.CustomDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_Application.ServiceContract
{
    public interface IStock_Repository
    {
        List<DiamondStockViewModel> GetStock();
    }
}
