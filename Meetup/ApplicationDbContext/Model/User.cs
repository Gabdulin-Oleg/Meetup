﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meetup.ApplicationDbContext.Model
{
    public class User
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public WorkStatus Work { get; set; }
        public int WorkExperience { get; set; }
        public string Post { get; set; }
        public IEnumerable<Language> Language { get; set; }
        public string AdditionalInformation { get; set; }
    }
}
