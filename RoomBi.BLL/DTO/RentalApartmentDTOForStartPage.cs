﻿using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class RentalApartmentDTOForStartPage
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double PricePerNight { get; set; }
        public double ObjectRating { get; set; }
        public string? Country { get; set; }
        public string? BookingFree { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
        public string? IngMap { get; set; }
        public string? LatMap { get; set; }
    }
}
