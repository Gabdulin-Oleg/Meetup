namespace Meetup.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// следует ли заплмнить
        /// </summary>
        public bool RememberMe { get; set; }

    }
}
