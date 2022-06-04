using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Primpasso.BLLInfra.Service;
using Primpasso.Models.DTO;
using System.Collections.Generic;


namespace Primpasso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobOpportunityController : ControllerBase
    {
        private readonly IJobOpportunityService jobOpportunityService;

        public JobOpportunityController(IJobOpportunityService jobOpportunityService)
        {
            this.jobOpportunityService = jobOpportunityService;
        }

        [HttpGet("{id}")]
        public ActionResult<JobOpportunityDTO> GetJobOpportunity(int id)
        {
            return Ok(jobOpportunityService.GetJobOpportunity(id));
        }

        [HttpGet("ForStatus/{jobTypeId}")]
        public ActionResult<ICollection<JobOpportunitySmallDTO>> GetJobOpportunitiesStatus(int? jobTypeId)
        {
            return Ok(jobOpportunityService.GetStatus(jobTypeId));
        }

        [HttpGet("ForCompany/{companyId}")]
        public ActionResult<ICollection<JobOpportunitySmallDTO>> GetJobOpportunitiesCompany(string companyLogin)
        {
            return Ok(jobOpportunityService.GetCompany(companyLogin));
        }

        [HttpGet("ForCandidate/{candidateId}")]
        public ActionResult<ICollection<JobOpportunitySmallDTO>> GetJobOpportunitiesCandidate(string candidateLogin)
        {
            return Ok(jobOpportunityService.GetCandidate(candidateLogin));
        }

        [HttpPost]
        public ActionResult PostJobOpportunity([FromBody] JobOpportunityNewDTO jobOpportunity)
        {
            jobOpportunityService.InsertJobOpportunity(jobOpportunity);
            return Ok();
        }

        [HttpPut]
        public ActionResult<JobOpportunityDTO> PutJobOpportunity([FromBody] JobOpportunityModifyDTO jobOpportunity)
        {
            return Ok(jobOpportunityService.ModifyJobOpportunity(jobOpportunity));
        }

        [HttpDelete("{jobOpportunityId}")]
        public ActionResult DeleteJobOpportunity(int jobOpportunityId)
        {
            jobOpportunityService.DeleteJobOpportunity(jobOpportunityId);
            return Ok();
        }
    }
}
