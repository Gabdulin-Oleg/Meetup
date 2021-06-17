namespace Meetup.ApplicationDbContext.Model
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? UserId { get; set; }
    }
}
