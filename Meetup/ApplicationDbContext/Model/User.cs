using Meetup.ApplicationDbContext.Model.Enums;
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
        public int Age { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// есть ли работа
        /// </summary>
        public bool IsWork { get; set; }
        /// <summary>
        /// Место работы
        /// </summary>
        public string PlaceWork { get; set; }
        /// <summary>
        /// Опыт работы
        /// </summary>
        public int WorkExperience { get; set; }
        /// <summary>
        /// Занимаема должность
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// Какими языками владеет
        /// </summary>
        public ICollection<Language> Language { get; set; }
        /// <summary>
        /// дополнительная иформация
        /// </summary>
        public string AdditionalInformation { get; set; }

        public ICollection<Meetups> Meetups { get; set; }
        public User()
        {
            Meetups = new List<Meetups>();
        }
    }
}
