using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Document.Domain;
using MediatR;

namespace Document.Api
{

    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, bool>
    {
        private readonly ICustomerDocumentRepository repository;

        public CreateDocumentHandler(ICustomerDocumentRepository documentRepository)
        {
            this.repository = documentRepository;
        }

        public async Task<bool> Handle(CreateDocumentCommand commmand, CancellationToken cancellationToken)
        {

            System.Console.WriteLine("Handled!");

            repository.UnitOfWork.BeginTransaction();

            try
            {
                repository.Add(commmand.Document);
                repository.UnitOfWork.CommitTransaction();
            }
            catch(Exception e)
            {
                repository.UnitOfWork.RollbackTransaction();
            }

            return await repository.UnitOfWork.SaveChangesAsync();


            // return Task.FromResult(true);
        }
    }

     public class QueryDocumentHandler : IRequestHandler<QueryCommand, IEnumerable<CustomerDocument>>
    {
        private readonly ICustomerDocumentRepository repository;

        public async Task<IEnumerable<CustomerDocument>> Handle(QueryCommand commmand, CancellationToken cancellationToken)
        {
            return repository.All<CustomerDocument>().ToList();
        }
    }
}