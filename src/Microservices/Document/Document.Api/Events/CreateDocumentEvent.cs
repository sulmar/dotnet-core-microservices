
using Document.Domain;
using MediatR;

namespace Document.Api
{
 public class CreateDocumentEvent : INotification
    {
        public CustomerDocument Document { get; set; }

        public CreateDocumentEvent(CustomerDocument document)
        {
            this.Document = document;
        }
    }
}