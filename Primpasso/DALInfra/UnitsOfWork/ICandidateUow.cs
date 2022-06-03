using Primpasso.DALInfra.Repositories;

namespace Primpasso.DALInfra.UnitsOfWork
{
    public interface ICandidateUow
    {
        public ICandidateRepository CandidateRepository { get; set; }
    }
}
