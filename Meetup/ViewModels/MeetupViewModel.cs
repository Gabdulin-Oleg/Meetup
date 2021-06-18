using Meetup.ApplicationDbContext.Model.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.ViewModels
{
    public class MeetupViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
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
    }
}
