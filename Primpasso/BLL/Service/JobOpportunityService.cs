using Primpasso.BLLInfra.Service;
using Primpasso.DALInfra.UnitsOfWork;
using Primpasso.Models.DTO;
using Primpasso.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primpasso.BLL.Service
{
    public class JobOpportunityService : IJobOpportunityService
    {
        private readonly IJobOpportunityUow jobOpportunityUow;

        public JobOpportunityService(IJobOpportunityUow jobOpportunityUow)
        {
            this.jobOpportunityUow = jobOpportunityUow;
        }

        public JobOpportunityDTO GetJobOpportunity(int id)
        {
            List<JobOpportunityDTO> jobOpportunity = jobOpportunityUow.JobOpportunityRepository.Get(id);

            if (jobOpportunity is null)
                throw new Exception("Não existe nenhuma vaga cadastrada para esse Id");

            return jobOpportunity[0];
        }

        public ICollection<JobOpportunitySmallDTO> GetStatus(int? jobTypeId)
        {
            var jobOpportunities = jobOpportunityUow.JobOpportunityRepository.GetAll();

            jobOpportunities = jobOpportunities.Where(x => jobTypeId is not null ? x.JobTypeId == jobTypeId : true).ToList();

            if (jobOpportunities.Count == 0)
                return null;

            List<JobOpportunitySmallDTO> jobOpportunitiesSmall = new();

            foreach (var jobOpportunity in jobOpportunities)
                jobOpportunitiesSmall.Add(new JobOpportunitySmallDTO
                {
                    Id = jobOpportunity.Id,
                    Company = jobOpportunity.Company,
                    JobType = jobOpportunity.JobType
                });

            return jobOpportunitiesSmall;
        }

        public ICollection<JobOpportunitySmallDTO> GetCompany(string companyLogin)
        {
            Company company = jobOpportunityUow.CompanyRepository.Get(companyLogin);

            if (company is null)
                throw new Exception("Este login não está cadastrado para nenhuma empresa");

            var jobOpportunities = jobOpportunityUow.JobOpportunityRepository.GetAll();

            jobOpportunities = jobOpportunities.Where(x => x.CompanyId == company.Id).ToList();

            if (jobOpportunities.Count == 0)
                return null;

            List<JobOpportunitySmallDTO> jobOpportunitiesSmall = new();

            foreach (var jobOpportunity in jobOpportunities)
                jobOpportunitiesSmall.Add(new JobOpportunitySmallDTO
                {
                    Id = jobOpportunity.Id,
                    Company = jobOpportunity.Company,
                    JobType = jobOpportunity.JobType
                });

            return jobOpportunitiesSmall;
        }

        public ICollection<JobOpportunitySmallDTO> GetCandidate(string candidateLogin)
        {
            Candidate candidate = jobOpportunityUow.CandidateRepository.Get(candidateLogin);

            if (candidate is null)
                throw new Exception("Este login não está cadastrado para nenhum candidato");

            var jobOpportunities = jobOpportunityUow.JobOpportunityRepository.GetAll();

            jobOpportunities = jobOpportunities.Where(x => x.Candidates.Any(y => y.Id == candidate.Id)).ToList();

            if (jobOpportunities.Count == 0)
                return null;

            List<JobOpportunitySmallDTO> jobOpportunitiesSmall = new();

            foreach (var jobOpportunity in jobOpportunities)
                jobOpportunitiesSmall.Add(new JobOpportunitySmallDTO
                {
                    Id = jobOpportunity.Id,
                    Company = jobOpportunity.Company,
                    JobType = jobOpportunity.JobType
                });

            return jobOpportunitiesSmall;
        }

        public void InsertJobOpportunity(JobOpportunityNewDTO jobOpportunity)
        {
            jobOpportunityUow.JobOpportunityRepository.Insert(new()
            {
                OpenDate = jobOpportunity.OpenDate,
                JobTypeId = jobOpportunity.JobTypeId,
                CompanyId = jobOpportunity.CompanyId,
                ClosingDate = jobOpportunity.ClosingDate,
                Description = jobOpportunity.Description
            });
        }

        public JobOpportunityDTO ModifyJobOpportunity(JobOpportunityModifyDTO jobOpportunity)
        {
            JobOpportunity jobOpportunityNew = new()
            {
                Id = jobOpportunity.Id,
                Description = jobOpportunity.Description,
                OpenDate = jobOpportunity.OpenDate,
                ClosingDate = jobOpportunity.ClosingDate,
                CompanyId = jobOpportunity.CompanyId,
                JobTypeId = jobOpportunity.JobTypeId
            };

            return jobOpportunityUow.JobOpportunityRepository.Update(jobOpportunityNew);
        }

        public void DeleteJobOpportunity(int jobOpportunityId)
        {
            jobOpportunityUow.JobOpportunityRepository.Delete(jobOpportunityUow.JobOpportunityRepository.GetEntity(jobOpportunityId));
        }
    }
}
