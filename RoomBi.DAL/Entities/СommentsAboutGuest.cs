using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBi.DAL
{
    public class CommentsAboutGuest
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateComments { get; set; }
        public int MasterIdUser { get; set; }
        //public User? Master { get; set; }
        public int GuestIdUser { get; set; }
        //public User? Guest { get; set; }
    }
}
