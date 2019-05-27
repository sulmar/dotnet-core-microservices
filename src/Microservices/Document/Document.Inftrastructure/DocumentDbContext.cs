using System;
using System.Threading.Tasks;
using Core.Infrastructure;
using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Inftrastructure
{
    public class DocumentDbContext : DbContext, IUnitOfWork
    {
        public DocumentDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CustomerDocumentConfiguration());
            
            base.OnModelCreating(builder);
        }

        public void BeginTransaction() => this.Database.BeginTransaction();

        public void RollbackTransaction() => this.Database.RollbackTransaction();

        public void CommitTransaction() => this.Database.CommitTransaction();

        public Task<bool> SaveChangesAsync() => this.SaveChangesAsync();

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDocument> CustomerDocuments { get; set; }
    }

   
}
