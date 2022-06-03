using Primpasso.Models.Entities;

namespace Primpasso.DALInfra.Repositories
{
    public interface ICompanyRepository
    {
        void Delete(Company company);
        Company Get(string login);
        Company Get(string login, string password);
        void Insert(Company company);
        Company Update(Company company);
    }
}