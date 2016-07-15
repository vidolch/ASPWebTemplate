namespace DataAccess.Models
{
    using System;

    public interface IAuditInfo
    {
        int Id { get; set; }

        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}