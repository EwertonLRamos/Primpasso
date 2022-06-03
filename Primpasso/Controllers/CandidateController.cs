using Incub.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Primpasso.BLLInfra.Service;
using Primpasso.Models.DTO;

namespace Primpasso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<UserLogedDTO> LoginCandidate([FromBody] UserLoginDTO userLogin)
        {
            var user = candidateService.GetCandidate(userLogin.Login, userLogin.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            return Ok(LoginService.GerarToken(user));
        }

        [HttpGet("Candidate/{candidateLogin}")]
        public ActionResult<UserDTO> GetCandidate(string candidateLogin)
        {
            return Ok(candidateService.GetCandidate(candidateLogin));
        }

        [HttpPost("Candidate")]
        [AllowAnonymous]
        public ActionResult PostCandidate([FromBody] NewUserDTO candidate)
        {
            candidateService.InsertCandidate(candidate);
            return Ok();
        }

        [HttpPut("Candidate")]
        public ActionResult<UserDTO> PutCandidate([FromBody] NewUserDTO candidate)
        {
            return Ok(candidateService.ModifyCandidate(candidate));
        }

        [HttpDelete("Candidate/{candidateLogin}")]
        public ActionResult DeleteCandidate(string candidateLogin)
        {
            candidateService.DeleteCandidate(candidateLogin);
            return Ok();
        }
    }
}
