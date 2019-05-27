using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Document.Api
{
    public class SendEmailHandler : INotificationHandler<CreateDocumentEvent>
    {
        public Task Handle(CreateDocumentEvent notification, CancellationToken cancellationToken)
        {
              Console.WriteLine($"send document {notification.Document.Number} via email");

              return Task.CompletedTask;
        }
    }

    public class SendSmsHandler : INotificationHandler<CreateDocumentEvent>
    {
        public Task Handle(CreateDocumentEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"send document {notification.Document.Number} via sms");

            return Task.CompletedTask;
     
        }
    }

}