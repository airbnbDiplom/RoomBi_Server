namespace RoomBi.DAL
{
    public class Language
    {
        public Language()
        {
            this.Users = new HashSet<User>();

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
