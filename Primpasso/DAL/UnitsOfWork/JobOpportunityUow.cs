using Primpasso.DALInfra.Repositories;
using Primpasso.DALInfra.UnitsOfWork;

namespace Primpasso.DAL.UnitsOfWork
{
    public class JobOpportunityUow : IJobOpportunityUow
    {
        public IJobOpportunityRepository JobOpportunityRepository { get; set; }
        public ICandidateRepository CandidateRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }

        public JobOpportunityUow(IJobOpportunityRepository jobOpportunityRepository, ICandidateRepository candidateRepository, ICompanyRepository companyRepository)
        {
            JobOpportunityRepository = jobOpportunityRepository;
            CandidateRepository = candidateRepository;
            CompanyRepository = companyRepository;
        }
    }
}
