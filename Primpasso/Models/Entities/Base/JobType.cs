using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primpasso.Models.Entities.Base
{
    [Table("JobType")]
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }


        public ICollection<JobOpportunity> JobOpportunities { get; set; }
    }
}
