using Primpasso.DALInfra.Repositories;

namespace Primpasso.DALInfra.UnitsOfWork
{
    public interface IJobOpportunityUow
    {
        public IJobOpportunityRepository JobOpportunityRepository { get; set; }
        public ICandidateRepository CandidateRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
    }
}
