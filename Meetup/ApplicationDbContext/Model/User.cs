using System.Collections.Generic;

namespace Meetup.ApplicationDbContext.Model
{
    public class User
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
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
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
        public IEnumerable<Language> Language { get; set; }
        /// <summary>
        /// дополнительная иформация
        /// </summary>
        public string AdditionalInformation { get; set; }
    }
}
