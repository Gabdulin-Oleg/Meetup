using System.ComponentModel.DataAnnotations;

namespace Meetup.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// следует ли заплмнить
        /// </summary>
        public bool RememberMe { get; set; }

    }
}
