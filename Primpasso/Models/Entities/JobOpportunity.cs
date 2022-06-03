using Primpasso.Models.Entities.Base;
using Primpasso.Models.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primpasso.Models.Entities
{
    [Table("JobOpportunity")]
    public class JobOpportunity : Entity 
    {
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosingDate { get; set; }


        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey(nameof(JobType))]
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }


        public ICollection<Candidate> Candidates { get; set; }
    }
}
