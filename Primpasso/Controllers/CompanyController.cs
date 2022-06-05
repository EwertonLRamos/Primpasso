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
            try
            {
                var user = companyService.GetCompany(userLogin.Login, userLogin.Senha);

                return Ok(LoginService.GerarToken(user));
            }
            catch (Exception e)
            {
                return NotFound(new { message =  e.Message });
            }
        }

        [HttpGet("{companyLogin}")]
        public ActionResult<UserDTO> GetCompany(string companyLogin)
        {
            return Ok(companyService.GetCompany(companyLogin));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostCompany([FromBody] NewUserDTO company)
        {
            companyService.InsertCompany(company);
            return Ok();
        }

        [HttpPut]
        public ActionResult<UserDTO> PutCompany([FromBody] NewUserDTO company)
        {
            return Ok(companyService.ModifyCompany(company));
        }

        [HttpDelete("{companyLogin}")]
        public ActionResult DeleteCompany(string companyLogin)
        {
            companyService.DeleteCompany(companyLogin);
            return Ok();
        }
    }
}
