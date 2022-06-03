using Primpasso.Models.Entities;
using Primpasso.Models.Entities.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primpasso.Models.Entities
{
    [Table("Company")]
    public class Company : UserEntity
    {
        public string CNPJ { get; set; }


        public ICollection<JobOpportunity> JobsOpportunity { get; set; }
    }
}
