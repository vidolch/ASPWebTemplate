namespace DataAccess.Models
{
    using System;

    public interface IAuditInfo
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}