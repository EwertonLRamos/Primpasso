using Incub.BLL.Services;
using Primpasso.BLLInfra.Service;
using Primpasso.DALInfra.UnitsOfWork;
using Primpasso.Models.DTO;
using Primpasso.Models.Entities;
using System;

namespace Primpasso.BLL.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateUow candidateUow;

        public CandidateService(ICandidateUow candidateUow)
        {
            this.candidateUow = candidateUow;
        }
        public UserDTO GetCandidate(string login)
        {
            Candidate candidate = candidateUow.CandidateRepository.Get(login);

            if (candidate is null)
                return null;

            return new UserDTO
            {
                Name = candidate.Name,
                Login = candidate.Login,
                Email = candidate.Email,
                IdentifierCode = candidate.CPF,
                PhoneNumber = candidate.PhoneNumber,
            };
        }

        public Candidate GetCandidate(string login, string password)
        {
            Candidate candidate = candidateUow.CandidateRepository.Get(login, LoginService.Cifrar(password));

            if (candidate is null)
                throw new Exception("Login ou senha invalidos.");

            if (candidate.IsDeleted)
                throw new Exception("Esse usuário foi excluído");

            return candidate;
        }

        public void InsertCandidate(NewUserDTO newCandidate)
        {
            if (GetCandidate(newCandidate.Login) is not null)
                throw new Exception("Já existe um candidato com este login.");

            newCandidate.Password = LoginService.Cifrar(newCandidate.Password);

            candidateUow.CandidateRepository.Insert(new()
            {
                Name = newCandidate.Name,
                Email = newCandidate.Email,
                Login = newCandidate.Login,
                Password = newCandidate.Password,
                CPF = newCandidate.IdentifierCode,
                PhoneNumber = newCandidate.PhoneNumber
            });
        }

        public UserDTO ModifyCandidate(NewUserDTO candidate)
        {
            var candidatoOld = candidateUow.CandidateRepository.Get(candidate.Login);
            
            if(candidatoOld is null)
                throw new Exception("Esse usuário não existe.");

            if (candidatoOld.Login != candidate.Login)
                throw new Exception("Não é possível modificar o login.");

            candidatoOld.Name = candidate.Name;
            candidatoOld.Email = candidate.Email;
            candidatoOld.Login = candidate.Login;
            candidatoOld.Password = LoginService.Cifrar(candidate.Password);
            candidatoOld.CPF = candidate.IdentifierCode;
            candidatoOld.PhoneNumber = candidate.PhoneNumber;

            Candidate newCandidate = candidateUow.CandidateRepository.Update(candidatoOld);

            return new UserDTO
            {
                Name = newCandidate.Name,
                Login = newCandidate.Login,
                Email = newCandidate.Email,
                IdentifierCode = newCandidate.CPF,
                PhoneNumber = newCandidate.PhoneNumber,
            };
        }

        public void DeleteCandidate(string login)
        {
            candidateUow.CandidateRepository.Delete(candidateUow.CandidateRepository.Get(login));
        }
    }
}
