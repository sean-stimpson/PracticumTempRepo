using System.Threading.Tasks;

namespace AAS.Data.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string from, string to, string subject, string body);
    }
}
