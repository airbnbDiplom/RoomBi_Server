﻿namespace RoomBi.BLL.DTO.New
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int RentalApartmentId { get; set; }
        public int MasterIdUser { get; set; }
        public int GuestIdUser { get; set; }

    }
}
