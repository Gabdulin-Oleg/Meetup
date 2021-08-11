using Meetup.ApplicationDbContext.Model.Enums;
using System;
using System.Collections.Generic;

namespace Meetup.ApplicationDbContext.Model
{
    public class User
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
        /// <summary>
        /// дополнительная иформация
        /// </summary>
        //public string AdditionalInformation { get; set; }

        public ICollection<Meetups> Meetups { get; set; }
        public User()
        {
            Meetups = new List<Meetups>();
        }
    }
}
