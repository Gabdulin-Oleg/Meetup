using Meetup.ApplicationDbContext.Model;
using Meetup.ApplicationDbContext.Model.Enums;
using System.Collections.Generic;
using System.IO;

namespace Meetup.Interfaces.Dtos
{
    public class MeetupDto
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
        public Stream Stream { get; set; }
        /// <summary>
        /// Продолжительнрсть метапа
        /// </summary>
        public double DurationMeetup { get; set; }

        public User Speaker { get; set; }

        public string MeetupLocationId { get; set; }


        public ICollection<UserDto> Users { get; set; }
    }
}
