﻿using RoomBi.BLL.DTO;
using RoomBi.BLL.DTO.New;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceOfAll<T> where T : class
    {
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
       
    }
    public interface IServiceProfile<T> where T : class
    {
        Task UpdateProfile(string fieldName, T item, int idUser);

    }
}
