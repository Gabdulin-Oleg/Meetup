using System;
using System.Collections.Generic;

namespace Meetup.ApplicationDbContext.Model
{
    public class MeetupLocation
    {
        /// <summary>
        /// ID 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Описание (адресс, контакты и т.д.)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Есть свободное время
        /// </summary>
        public bool IsFreeTime { get; set; }
        /// <summary>
        /// начало свободного времи 
        /// </summary>
        public DateTime StartFreeTime { get; set; }
        /// <summary>
        /// Конец свободного времи 
        /// </summary>
        public DateTime EndFreeTime { get; set; }

        public ICollection<Meetups> Meetups { get; set; }

    }
}
