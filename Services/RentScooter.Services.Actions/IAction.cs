namespace RentScooter.Services.Actions;

using RentScooter.Services.EmailSender;
using System.Threading.Tasks;

public interface IAction
{
    Task SendEmail(EmailModel email);
}
