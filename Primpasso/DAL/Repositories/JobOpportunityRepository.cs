using Primpasso.Context;
using Primpasso.DALInfra.Repositories;
using Primpasso.Models.DTO;
using Primpasso.Models.Dummies;
using Primpasso.Models.Entities;
using Primpasso.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Primpasso.DAL.Repositories
{
    public class JobOpportunityRepository : BaseRepository, IJobOpportunityRepository
    {
        public JobOpportunityRepository(PrimpassoDbContext primpassoDbContext) : base(primpassoDbContext)
        { }

        public List<JobOpportunityDTO> Get(int id)
        {
            List<JobOpportunityDTO> jobOpportunities = primpassoDbContext.JobOpportunity
                .Where(x => x.OpenDate <= DateTime.Now && x.ClosingDate >= DateTime.Now)
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new JobOpportunityDTO
                {
                    Id = x.Id,
                    OpenDate = x.OpenDate,
                    Company = x.Company.Name,
                    Description = x.Description,
                    ClosingDate = x.ClosingDate,
                    JobType = x.JobType.Description
                }).ToList();

            return jobOpportunities;
        }

        public JobOpportunity GetEntity(int Id)
        {
            return primpassoDbContext.JobOpportunity.FirstOrDefault(x => x.Id == Id);
        }

        public List<JobOpportunityDummy> GetAll()
        {
            List<JobOpportunityDummy> jobOpportunities = primpassoDbContext.JobOpportunity
                .Where(x => x.OpenDate >= DateTime.Now && x.ClosingDate <= DateTime.Now)
                .Where(x => !x.IsDeleted)
                .Select(x => new JobOpportunityDummy
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    JobTypeId = x.JobTypeId,
                    Company = x.Company.Name,
                    JobType = x.JobType.Description,
                    Candidates = x.Candidates.ToList()
                }).ToList();

            return jobOpportunities;
        }

        public void Insert(JobOpportunity jobOpportunity)
        {
            primpassoDbContext.JobOpportunity.Add(jobOpportunity);
            primpassoDbContext.SaveChanges();
        }

        public JobOpportunityDTO Update(JobOpportunity jobOpportunity)
        {
            var jobOpportunitySaved = primpassoDbContext.JobOpportunity.Update(jobOpportunity);
            primpassoDbContext.SaveChanges();

            var jobOpportunityEntity = primpassoDbContext.JobOpportunity
                .Where(x => x.Id == jobOpportunitySaved.Entity.Id)
                .Select(x => new
                {
                    x.Id,
                    x.OpenDate,
                    x.ClosingDate,
                    x.Description,
                    CompanyName = x.Company.Name,
                    JobTypeDescription = x.JobType.Description
                })
                .ToList();

            return new JobOpportunityDTO
            {
                Id = jobOpportunityEntity[0].Id,
                OpenDate = jobOpportunityEntity[0].OpenDate,
                ClosingDate = jobOpportunityEntity[0].ClosingDate,
                Description = jobOpportunityEntity[0].Description,
                Company = jobOpportunityEntity[0].CompanyName,
                JobType = jobOpportunityEntity[0].JobTypeDescription
            };
        }

        public void Delete(JobOpportunity jobOpportunity)
        {
            jobOpportunity.IsDeleted = true;

            Update(jobOpportunity);
            primpassoDbContext.SaveChanges();
        }

        public JobType GetJobType(int jobtypeId)
        {
            return primpassoDbContext.JobType.FirstOrDefault(x => x.Id == jobtypeId);
        }
    }
}
