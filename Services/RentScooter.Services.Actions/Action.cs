namespace RentScooter.Services.Actions;

using RentScooter.Consts;
using RentScooter.Services.EmailSender;
using RentScooter.Services.RabbitMq;
using System.Threading.Tasks;

public class Action : IAction
{
    private readonly IRabbitMq rabbitMq;

    public Action(IRabbitMq rabbitMq)
    {
        this.rabbitMq = rabbitMq;
    }

    public async Task SendEmail(EmailModel email)
    {
        await rabbitMq.PushAsync(RabbitMqTaskQueueNames.SEND_EMAIL, email);
    }

    public async Task SendStartRentEmail(EmailModel email)
    {
        await rabbitMq.PushAsync(RabbitMqTaskQueueNames.SCOOTER_RENTED, email);
    }

    public async Task SendStopRentEmail(EmailModel email)
    {
        await rabbitMq.PushAsync(RabbitMqTaskQueueNames.SCOOTER_RETURNED, email);
    }

}
