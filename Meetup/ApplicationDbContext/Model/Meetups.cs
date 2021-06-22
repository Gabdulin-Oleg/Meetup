using Meetup.ApplicationDbContext.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetup.ApplicationDbContext.Model
{
    public class Meetups
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Тип Метапа
        /// </summary>
        public MeetupTypes Type { get; set; }
        /// <summary>
        /// Тема Метапа
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Картинки
        /// </summary>
        public byte[] Images { get; set; }
        /// <summary>
        /// Продолжительнрсть метапа
        /// </summary>
        public double DurationMeetup { get; set; }
        /// <summary>
        /// Выступающий
        /// </summary>
        [NotMapped]
        public User Speaker { get; set; }

        public string MeetupLocationId { get; set; }
        public MeetupLocation MeetupLocation { get; set; }

        public ICollection<User> Users { get; set; }
        public Meetups()
        {
            Users = new List<User>();
        }
    }
}
