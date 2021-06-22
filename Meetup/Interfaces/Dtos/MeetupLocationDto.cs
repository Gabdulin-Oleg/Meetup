using System;
using System.Collections.Generic;

namespace Meetup.Interfaces.Dtos
{
    public class MeetupLocationDto
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
        /// начало свободного времи 
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Конец свободного времи 
        /// </summary>
        public DateTime EntTime { get; set; }
        public bool IsFreeTime { get; set; }
        public ICollection<MeetupDto> Meetups { get; set; }
    }
}
