namespace Meetup.ApplicationDbContext.Model
{
    public class Language
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
