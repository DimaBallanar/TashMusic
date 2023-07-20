using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicServer.Models.Repository;
using MusicServer.Repository;

namespace MusicServer.Controllers
{
    [ApiController]
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository m_userRepository;
        public UserController(UserRepository userRepository)
        {
            m_userRepository = userRepository;
        }

        //https://localhost:7172/api/User
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(m_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //https://localhost:7172/api/User/get/1     
        //[HttpGet("get/{id}")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        return Ok(m_userRepository.GetAll(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPost("[action]")]
        public IActionResult GetByEmail(string email, string pass)
        {
            try
            {
                return Ok(m_userRepository.GetByEmail(email, pass));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(User user) 
        {
            try
            {
                return Ok(m_userRepository.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            try
            {
                return Ok(m_userRepository.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(m_userRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
