using Meetup.ApplicationDbContext.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.ViewModels
{
    public class RegistredViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public WorkStatus Work { get; set; }
        public int WorkExperience { get; set; }
        public string Post { get; set; }
        [Required]
        public IEnumerable<Language> Language { get; set; }
        [StringLength(1000)]
        public string AdditionalInformation { get; set; }
    }
}
