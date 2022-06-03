using Primpasso.Models.DTO;
using Primpasso.Models.Entities;

namespace Primpasso.BLLInfra.Service
{
    public interface ICandidateService
    {
        void DeleteCandidate(string login);
        UserDTO GetCandidate(string login);
        Candidate GetCandidate(string login, string password);
        void InsertCandidate(NewUserDTO newCandidate);
        UserDTO ModifyCandidate(NewUserDTO candidate);
    }
}