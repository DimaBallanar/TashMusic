//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.Models;
//using WebApplication1.Services;

//namespace WebApplication1.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class LanguageController : Controller
//    {
//        [HttpGet("getall")]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                LanguageServices languageServices = new LanguageServices();
//                return Ok(await languageServices.GetAll());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }


//        // https://localhost:7283/api/Language/getall/react
//        [HttpGet("getall/{id}")]
//        public async Task<IActionResult> Get(string id)
//        {
//            try
//            {
//                LanguageServices languageServices = new LanguageServices();
//                return Ok(await languageServices.GetById(id));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // https://localhost:7283/api/Language/create/react
//        [HttpPost("create")]
//        public async Task<IActionResult> Create(Language data)
//        {
//            try
//            {
//                LanguageServices LangServ = new LanguageServices();
//                await LangServ.Create(data);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete("update/{id}")]
//        public async Task<IActionResult> Update(Language data)
//        {
//            try
//            {
//                LanguageServices LangServ = new LanguageServices();
//                await LangServ.Update(data);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete("delete/{id}")]
//        public async Task<IActionResult> Delete(string id)
//        {
//            try
//            {
//                LanguageServices LangServ = new LanguageServices();
//                await LangServ.Delete(id);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }


//    }
//}
