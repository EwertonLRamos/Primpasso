using Primpasso.Models.DTO;
using Primpasso.Models.Entities;
using System.Collections.Generic;

namespace Primpasso.BLLInfra.Service
{
    public interface IJobOpportunityService
    {
        void DeleteJobOpportunity(int jobOpportunityId);
        ICollection<JobOpportunitySmallDTO> GetCandidate(string candidateLogin);
        ICollection<JobOpportunitySmallDTO> GetCompany(string companyLogin);
        JobOpportunityDTO GetJobOpportunity(int id);
        ICollection<JobOpportunitySmallDTO> GetStatus(int? jobTypeId);
        JobOpportunityDTO ModifyJobOpportunity(JobOpportunityModifyDTO jobOpportunity);
        void InsertJobOpportunity(JobOpportunityNewDTO jobOpportunity);
    }
}