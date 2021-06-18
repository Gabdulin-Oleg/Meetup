using Meetup.ApplicationDbContext.Model;
using Meetup.ApplicationDbContext.Model.Enums;
using System.Collections.Generic;

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
        public byte[] Images { get; set; }


        public ICollection<User> Users { get; set; }
    }
}
