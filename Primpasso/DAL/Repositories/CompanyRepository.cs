using Primpasso.Context;
using Primpasso.DALInfra.Repositories;
using Primpasso.Models.Entities;
using System.Linq;

namespace Primpasso.DAL.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(PrimpassoDbContext primpassoDbContext) : base(primpassoDbContext)
        { }

        public Company Get(string login)
        {
            return primpassoDbContext.Company.FirstOrDefault(x => x.Login == login && !x.IsDeleted);
        }

        public Company Get(string login, string password)
        {
            return primpassoDbContext.Company.FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public void Insert(Company company)
        {
            primpassoDbContext.Company.Add(company);
            primpassoDbContext.SaveChanges();
        }

        public Company Update(Company company)
        {
            var query = primpassoDbContext.Company.Update(company);
            primpassoDbContext.SaveChanges();

            return query.Entity;
        }

        public void Delete(Company company)
        {
            company.IsDeleted = true;

            Update(company);
            primpassoDbContext.SaveChanges();
        }
    }
}
