using Primpasso.Models.DTO;
using Primpasso.Models.Entities;

namespace Primpasso.BLLInfra.Service
{
    public interface ICompanyService
    {
        UserDTO GetCompany(string login);
        Company GetCompany(string login, string senha);
        void InsertCompany(NewUserDTO newCompany);
        UserDTO ModifyCompany(NewUserDTO company);
        void DeleteCompany(string login);
    }
}