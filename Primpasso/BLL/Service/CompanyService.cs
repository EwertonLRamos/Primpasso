using Incub.BLL.Services;
using Primpasso.BLLInfra.Service;
using Primpasso.DALInfra.UnitsOfWork;
using Primpasso.Models.DTO;
using Primpasso.Models.Entities;
using System;

namespace Primpasso.BLL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyUow companyUow;

        public CompanyService(ICompanyUow companyUow)
        {
            this.companyUow = companyUow;
        }

        public UserDTO GetCompany(string login)
        {
            Company company = companyUow.CompanyRepository.Get(login);

            if(company is null)
                return null;

            return new UserDTO 
            {
                Name = company.Name,
                Login = company.Login,
                Email = company.Email,
                IdentifierCode = company.CNPJ,
                PhoneNumber = company.PhoneNumber,
            };
        }

        public Company GetCompany(string login, string password)
        {
            Company company = companyUow.CompanyRepository.Get(login, LoginService.Cifrar(password));

            if (company is null)
                throw new Exception("Login ou senha invalidos.");

            if (company.IsDeleted)
                throw new Exception("Esse usuário foi excluído");

            return company; 
        }

        public void InsertCompany(NewUserDTO newCompany)
        {
            if (GetCompany(newCompany.Login) is not null)
                throw new Exception("Já existe uma empresa com este login.");

            newCompany.Password = LoginService.Cifrar(newCompany.Password);

            companyUow.CompanyRepository.Insert(new()
            {
                Name = newCompany.Name,
                Email = newCompany.Email,
                Login = newCompany.Login,
                Password = newCompany.Password,
                CNPJ = newCompany.IdentifierCode,
                PhoneNumber = newCompany.PhoneNumber
            });
        }

        public UserDTO ModifyCompany(NewUserDTO company)
        {
            var empresaOld = companyUow.CompanyRepository.Get(company.Login);

            if(empresaOld is null)
                throw new Exception("Essa empresa não existe.");

            if (empresaOld.Login != company.Login)
                throw new Exception("Não é possível modificar o login."); 

            empresaOld.Name = company.Name;
            empresaOld.Email = company.Email;
            empresaOld.Login = company.Login;
            empresaOld.Password = LoginService.Cifrar(company.Password);
            empresaOld.CNPJ = company.IdentifierCode;
            empresaOld.PhoneNumber = company.PhoneNumber;

            Company newCompany = companyUow.CompanyRepository.Update(empresaOld);

            return new UserDTO
            {
                Name = newCompany.Name,
                Login = newCompany.Login,
                Email = newCompany.Email,
                IdentifierCode = newCompany.CNPJ,
                PhoneNumber = newCompany.PhoneNumber,
            };
        }

        public void DeleteCompany(string login)
        {
            companyUow.CompanyRepository.Delete(companyUow.CompanyRepository.Get(login));
        }
    }
}
