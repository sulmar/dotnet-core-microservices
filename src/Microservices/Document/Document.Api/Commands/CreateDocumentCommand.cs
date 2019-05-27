using System;
using System.Threading;
using System.Threading.Tasks;
using Document.Domain;
using MediatR;

namespace Document.Api
{
    public class CreateDocumentCommand  : IRequest<bool>
    { 
        public CustomerDocument Document { get; set; }

        public CreateDocumentCommand(CustomerDocument document)
        {
            this.Document = document;
        }

    }

    
}