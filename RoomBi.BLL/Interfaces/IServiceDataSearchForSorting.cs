﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceDataSearchForSorting<T> where T : class
    {
        Task<IEnumerable<T>> TempGetAll(string temp);
    }
}
