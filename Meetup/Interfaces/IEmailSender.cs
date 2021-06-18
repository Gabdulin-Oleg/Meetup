using System.Threading.Tasks;

namespace Meetup.Interfaces
{
    public interface IEmailSender
    {
        /// <summary>
        /// отправка сообщения не Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}