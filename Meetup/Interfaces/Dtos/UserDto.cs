using Meetup.ApplicationDbContext.Model;
using Meetup.ApplicationDbContext.Model.Enums;
using System;
using System.Collections.Generic;

namespace Meetup.Interfaces.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public DateTime Age { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// есть ли работа
        /// </summary>
        public bool WorkHas { get; set; }
        /// <summary>
        /// Место работы
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Опыт работы
        /// </summary>
        public string WorkExperience { get; set; }
        /// <summary>
        /// Занимаема должность
        /// </summary>
        public string WorkPosition { get; set; }
        /// <summary>
        /// Какими языками владеет
        /// </summary>
        public string Prof { get; set; }

    }
}
