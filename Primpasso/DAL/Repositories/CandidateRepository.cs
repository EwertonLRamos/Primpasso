using Primpasso.Context;
using Primpasso.DALInfra.Repositories;
using Primpasso.Models.Entities;
using System.Linq;

namespace Primpasso.DAL.Repositories
{
    public class CandidateRepository : BaseRepository, ICandidateRepository
    {
        public CandidateRepository(PrimpassoDbContext primpassoDbContext) : base(primpassoDbContext)
        { }

        public Candidate Get(string login)
        {
            return primpassoDbContext.Candidate.FirstOrDefault(x => x.Login == login && x.IsDeleted);
        }

        public Candidate Get(string login, string password)
        {
            return primpassoDbContext.Candidate.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public void Insert(Candidate candidate)
        {
            primpassoDbContext.Candidate.Add(candidate);
            primpassoDbContext.SaveChanges();
        }

        public Candidate Update(Candidate candidate)
        {
            var query = primpassoDbContext.Candidate.Update(candidate);
            primpassoDbContext.SaveChanges();

            return query.Entity;
        }

        public void Delete(Candidate candidate)
        {
            candidate.IsDeleted = true;

            Update(candidate);
            primpassoDbContext.SaveChanges();
        }
    }
}
