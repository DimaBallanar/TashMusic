using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MusicServer.Models.ApiRequest;
using MusicServer.Models.Options;
using MusicServer.Services;

namespace MusicServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService m_accountService;

        public AccountController(AccountService accountService)
        {
            m_accountService = accountService;
        }
        [HttpPost("[action]")]
        public TokenData Login(Login login)
        {
            return m_accountService.Token(login.NickName, login.Password);
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return Ok();
        //}
    }
}
