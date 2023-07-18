using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicServer.Models.Repository;
using MusicServer.Repository;
using System.Data;

namespace MusicServer.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly GenreRepository m_genreRepository;

        public GenreController(GenreRepository genreRepository)
        {
            m_genreRepository = genreRepository;
        }

        [HttpGet]
        public IActionResult GetAllGenre()
        {
            try
            {
                return Ok(m_genreRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            try
            {
                return Ok(m_genreRepository.Put(genre));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       
    }
}
