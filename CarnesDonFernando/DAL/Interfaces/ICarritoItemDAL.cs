﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICarritoItemDAL : IDALGenerico<CarritoItem>
    {
        bool RemoveRangeCarrito(IEnumerable<CarritoItem> entities);
    }
}
