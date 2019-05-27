using System;
using Core.Infrastructure;

namespace Document.Domain
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}