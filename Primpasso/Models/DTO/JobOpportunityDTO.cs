using System;

namespace Primpasso.Models.DTO
{
    public class JobOpportunityDTO : JobOpportunitySmallDTO
    {
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosingDate { get; set; }
    }
}
