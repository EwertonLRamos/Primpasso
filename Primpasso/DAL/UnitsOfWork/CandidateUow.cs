using Primpasso.DALInfra.Repositories;
using Primpasso.DALInfra.UnitsOfWork;

namespace Primpasso.DAL.UnitsOfWork
{
    public class CandidateUow : ICandidateUow
    {
        public ICandidateRepository CandidateRepository { get; set; }

        public CandidateUow(ICandidateRepository candidateRepository)
        {
            CandidateRepository = candidateRepository;
        }
    }
}
