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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }


        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult<UserLogedDTO> LoginCompany([FromBody] UserLoginDTO userLogin)
        {
            var user = companyService.GetCompany(userLogin.Login, userLogin.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            return Ok(LoginService.GerarToken(user));
        }

        [HttpGet("Company/{companyLogin}")]
        public ActionResult<UserDTO> GetCompany(string companyLogin)
        {
            return Ok(companyService.GetCompany(companyLogin));
        }

        [HttpPost("Company")]
        [AllowAnonymous]
        public ActionResult PostCompany([FromBody] NewUserDTO company)
        {
            companyService.InsertCompany(company);
            return Ok();
        }

        [HttpPut("Company")]
        public ActionResult<UserDTO> PutCompany([FromBody] NewUserDTO company)
        {
            return Ok(companyService.ModifyCompany(company));
        }

        [HttpDelete("Company/{companyLogin}")]
        public ActionResult DeleteCompany(string companyLogin)
        {
            companyService.DeleteCompany(companyLogin);
            return Ok();
        }
    }
}
