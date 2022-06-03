using Primpasso.Models.Entities.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primpasso.Models.Entities
{
    [Table("Candidate")]
    public class Candidate : UserEntity
    {
        public string CPF { get; set; }


        public ICollection<JobOpportunity> JobOpportunities { get; set; }
    }
}
