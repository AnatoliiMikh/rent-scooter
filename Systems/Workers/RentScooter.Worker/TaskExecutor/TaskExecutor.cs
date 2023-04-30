﻿namespace RentScooter.Worker;

using RentScooter.Consts;
using RentScooter.Services.EmailSender;
using RentScooter.Services.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public class TaskExecutor : ITaskExecutor
{
    private readonly ILogger<TaskExecutor> logger;
    private readonly IServiceProvider serviceProvider;
    private readonly IRabbitMq rabbitMq;

    public TaskExecutor(
        ILogger<TaskExecutor> logger,
        IServiceProvider serviceProvider,
        IRabbitMq rabbitMq
    )
    {
        this.logger = logger;
        this.serviceProvider = serviceProvider;
        this.rabbitMq = rabbitMq;
    }

    private async Task Execute<T>(Func<T, Task> action)
    {
        try
        {
            using var scope = serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<T>();
            if (service != null)
                await action(service);
            else
                logger.LogError($"Error: {action.ToString()} wasn`t resolved");
        }
        catch (Exception e)
        {
            logger.LogError($"Error: {RabbitMqTaskQueueNames.SEND_EMAIL}: {e.Message}");
            throw;
        }
    }

    public void Start()
    {        
        rabbitMq.Subscribe<EmailModel>(RabbitMqTaskQueueNames.SEND_EMAIL, async data
            => await Execute<IEmailSender>(async service =>
            {
                logger.LogDebug($"RABBITMQ::: {RabbitMqTaskQueueNames.SEND_EMAIL}: {data.Email} {data.Message}");
                await service.Send(data);
            }));
    }

    public void StartRent()
    {
                rabbitMq.Subscribe<EmailModel>(RabbitMqTaskQueueNames.SCOOTER_RENTED, async data
            => await Execute<IEmailSender>(async service =>
            {
                logger.LogDebug($"RABBITMQ::: {RabbitMqTaskQueueNames.SCOOTER_RENTED}: {data.Email} {data.Message}");
                await service.Send(data);
            }));

    }

    public void StopRent() 
    {
                rabbitMq.Subscribe<EmailModel>(RabbitMqTaskQueueNames.SCOOTER_RETURNED, async data
            => await Execute<IEmailSender>(async service =>
            {
                logger.LogDebug($"RABBITMQ::: {RabbitMqTaskQueueNames.SCOOTER_RETURNED}: {data.Email} {data.Message}");
                await service.Send(data);
            }));

    }
}