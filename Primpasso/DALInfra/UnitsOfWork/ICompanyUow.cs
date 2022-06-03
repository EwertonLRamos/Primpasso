using Primpasso.DALInfra.Repositories;

namespace Primpasso.DALInfra.UnitsOfWork
{
    public interface ICompanyUow
    {
        ICompanyRepository CompanyRepository { get; set; }
    }
}