﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public interface IRepositoryCountry<T> where T : class
    {
        Task<T> GetByName(string name);
    }
}
