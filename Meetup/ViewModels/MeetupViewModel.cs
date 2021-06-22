using Meetup.ApplicationDbContext.Model.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Meetup.ViewModels
{
    public class MeetupViewModel
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
        public IFormFile Images { get; set; }
        /// <summary>
        /// Продолжительнрсть метапа
        /// </summary>
        public double DurationMeetup { get; set; }

        public string meetupLocationId { get; set; }
    }
}
