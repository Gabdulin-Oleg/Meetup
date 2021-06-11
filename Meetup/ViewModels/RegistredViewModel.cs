using Meetup.ApplicationDbContext.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meetup.ViewModels
{
    public class RegistredViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя 
        /// </summary>
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        [Required]
        public int Age { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// есть ли работа
        /// </summary>
        [Required]
        public WorkStatus Work { get; set; }
        /// <summary>
        /// опыт работы
        /// </summary>
        public int WorkExperience { get; set; }
        /// <summary>
        /// занимаемый пост
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// владение языками
        /// </summary>
        [Required]
        public IEnumerable<Language> Language { get; set; }
        /// <summary>
        /// дополниткльныя информация
        /// </summary>
        [StringLength(1000)]
        public string AdditionalInformation { get; set; }
    }
}
