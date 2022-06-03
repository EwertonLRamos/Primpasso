using Primpasso.DALInfra.Repositories;
using Primpasso.DALInfra.UnitsOfWork;

namespace Primpasso.DAL.UnitsOfWork
{
    public class CompanyUow : ICompanyUow
    {
        public ICompanyRepository CompanyRepository { get; set; }

        public CompanyUow(ICompanyRepository companyRepository)
        {
            CompanyRepository = companyRepository;
        }
    }
}
