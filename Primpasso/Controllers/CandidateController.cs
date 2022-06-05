using Incub.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Primpasso.BLLInfra.Service;
using Primpasso.Models.DTO;
using System;

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
            try
            {
                var user = candidateService.GetCandidate(userLogin.Login, userLogin.Senha);

                return Ok(LoginService.GerarToken(user));
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("{candidateLogin}")]
        public ActionResult<UserDTO> GetCandidate(string candidateLogin)
        {
            return Ok(candidateService.GetCandidate(candidateLogin));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostCandidate([FromBody] NewUserDTO candidate)
        {
            candidateService.InsertCandidate(candidate);
            return Ok();
        }

        [HttpPut]
        public ActionResult<UserDTO> PutCandidate([FromBody] NewUserDTO candidate)
        {
            return Ok(candidateService.ModifyCandidate(candidate));
        }

        [HttpDelete("{candidateLogin}")]
        public ActionResult DeleteCandidate(string candidateLogin)
        {
            candidateService.DeleteCandidate(candidateLogin);
            return Ok();
        }
    }
}
