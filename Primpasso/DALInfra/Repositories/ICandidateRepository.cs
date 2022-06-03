using Primpasso.Models.Entities;

namespace Primpasso.DALInfra.Repositories
{
    public interface ICandidateRepository
    {
        void Delete(Candidate candidate);
        Candidate Get(string login);
        Candidate Get(string login, string password);
        void Insert(Candidate candidate);
        Candidate Update(Candidate candidate);
    }
}