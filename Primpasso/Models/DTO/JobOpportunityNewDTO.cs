using System;

namespace Primpasso.Models.DTO
{
    public class JobOpportunityNewDTO
    {
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int CompanyId { get; set; }
        public int JobTypeId { get; set; }
    }
}
