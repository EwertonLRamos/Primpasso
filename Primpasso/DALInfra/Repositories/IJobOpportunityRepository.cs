using Primpasso.Models.DTO;
using Primpasso.Models.Dummies;
using Primpasso.Models.Entities;
using Primpasso.Models.Entities.Base;
using System.Collections.Generic;

namespace Primpasso.DALInfra.Repositories
{
    public interface IJobOpportunityRepository
    {
        void Delete(JobOpportunity jobOpportunity);
        List<JobOpportunityDTO> Get(int id);
        List<JobOpportunityDummy> GetAll();
        JobOpportunity GetEntity(int Id);
        public JobType GetJobType(int jobtypeId);
        void Insert(JobOpportunity jobOpportunity);
        JobOpportunityDTO Update(JobOpportunity jobOpportunity);
    }
}