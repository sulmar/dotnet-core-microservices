using System;
using Core.Infrastructure;

namespace Document.Domain
{
    public class CustomerDocument : BaseEntity
    {
        public string Number { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
