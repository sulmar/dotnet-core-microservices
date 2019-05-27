using System;

namespace Core.Infrastructure
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    
        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdatedOn = DateTime.Now;
        }
    }
}
