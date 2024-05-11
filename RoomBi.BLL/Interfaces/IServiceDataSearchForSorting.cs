﻿using RoomBi.BLL.DTO;
using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceDataSearchForSorting<T> where T : class
    {
        Task<IEnumerable<T>> GetAllByFilter(Filter filter);
        Task<IEnumerable<T>> GetNearestRooms(string ingMap, string latMap); 
        Task<IEnumerable<T>> AlexSearch(DataSearchForSorting dataSearchForSorting, int page, int pageSize);
    }
} 




//public interface IServiceForSorting<T> where T : class
    //{
    //    Task<T> NewRentalApartment(RentalApartment apartment);
    //}
//Task<IEnumerable<T>> GetAllByType(Where where);

//Task<IEnumerable<T>> GetAllByNumberOfGuests(int? why, IEnumerable<RentalApartment>? rentalApartment = null);
