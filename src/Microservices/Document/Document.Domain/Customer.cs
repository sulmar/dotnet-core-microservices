using System;
using Core.Infrastructure;

namespace Document.Domain
{
    public class Customer : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}