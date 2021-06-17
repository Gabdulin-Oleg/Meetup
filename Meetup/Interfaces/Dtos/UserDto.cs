using Meetup.ApplicationDbContext.Model;
using Meetup.ApplicationDbContext.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Interfaces.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// есть ли работа
        /// </summary>
        public WorkStatus Work { get; set; }
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
    }
}
