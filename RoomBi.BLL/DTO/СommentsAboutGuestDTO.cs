using System.ComponentModel.DataAnnotations.Schema;
using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class CommentsAboutGuestDTO
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateComments { get; set; }
        public int MasterId { get; set; }
        public string? MasterName { get; set; }// Имя хозяина
        public string? MasterAvatar { get; set; } // Аватар хозяина
    }
}
