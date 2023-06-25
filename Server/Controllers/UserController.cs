using Microsoft.AspNetCore.Mvc;
using Server.Repository;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepositoty m_userRepositoty;
        public UserController(UserRepository userRepository)
        {
            m_userRepository = userRepository;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                UserController languageServices = new LanguageServices();
                return Ok(await languageServices.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // https://localhost:7283/api/Language/create/react
        [HttpPost("create")]
        public async Task<IActionResult> Create(Language data)
        {
            try
            {
                LanguageServices LangServ = new LanguageServices();
                await LangServ.Create(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
              

    
    }
}
