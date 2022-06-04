using Primpasso.Models.DTO;
using Primpasso.Models.Entities;
using System.Collections.Generic;

namespace Primpasso.Models.Dummies
{
    public class JobOpportunityDummy : JobOpportunitySmallDTO
    {
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
